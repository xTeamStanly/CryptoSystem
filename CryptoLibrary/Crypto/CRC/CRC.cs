using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Library.Crypto {
    
    public class CRC {

        // istorija checksum racunice, treba nam za interfejs
        public static List<CRCFileItem> FileHistory = new List<CRCFileItem>();
        public static List<CRCTextItem> TextFileHistory = new List<CRCTextItem>();
        public static List<CRCPlaintextItem> PlaintextHistory = new List<CRCPlaintextItem>();

        private BitArray polynomial;
        public BitArray Polynomial { get { return polynomial; } }
        private int polynomial_length = 0;
        private int padding_lenght = 0;

        // crc lookup tabela
        private ulong[] lookup_table = new ulong[256];
        private int thread_count = 1;

        private bool possible_overflow = false;
        public bool PossibleOverflow { get { return possible_overflow; } }

        public static string unsigned_to_hexstring(ulong input) {
            return "0x" + input.ToString("X").ToUpper();
        }

        private static ulong binary_string_to_ulong(string bits) {
            if (bits == null) { throw new ArgumentNullException("Bit array is null"); }

            uint result = 0;
            uint bitValue = 1;

            foreach (char bit in bits.Reverse()) {
                if (bit == '1') {
                    result |= bitValue;
                }

                bitValue = bitValue << 1;
            }

            return result;
        }

        private static string crc_polynomial_regex = @"^(0|1)+$";
        public static BitArray unicode_poynomial_to_bitarray(string unicode_polynomial) {
            unicode_polynomial = unicode_polynomial.Trim().TrimStart('0');
            if (unicode_polynomial.Length == 0) { throw new Exception("Invalid polynomial"); }

            bool valid_polynomial = Regex.IsMatch(unicode_polynomial, crc_polynomial_regex);
            if (valid_polynomial == false) { throw new Exception("Invalid polynomial"); }

            BitArray polynomial = new BitArray(unicode_polynomial.ToCharArray().Select(i => i == '1').ToArray());
            return polynomial;
        }

        public CRC(string unicode_polynomial) {
            if (unicode_polynomial == null) { throw new ArgumentNullException("Polynomial is null"); }

            // CRC checksum smestamo u ulong (64bit), a checksum radimo byte-po-byte (8bit).
            // Najveci padding koji mozemo da dodamo 8bit-nom podatku, a da ne predjemo 64bit
            // jeste padding od 56bit-a, sto znaci da je najveci polinom koji ne dovodi to
            // shift overflow-a 57 stepeni polinom
            if (unicode_polynomial.Length > 57) { possible_overflow = true; }

            polynomial = unicode_poynomial_to_bitarray(unicode_polynomial);
            polynomial_length = polynomial.Length;
            padding_lenght = polynomial_length - 1;

           calculate_lookup_table();
        }

        public CRC(string unicode_polynomial, int thread_count) {
            thread_count = Math.Abs(thread_count);
            if (thread_count == 0) {
                this.thread_count = 1;
            } else {
                this.thread_count = thread_count;
            }

            if (unicode_polynomial.Length > 57) { possible_overflow = true; }

            polynomial = unicode_poynomial_to_bitarray(unicode_polynomial);
            polynomial_length = polynomial.Length;
            padding_lenght = polynomial_length - 1;

            calculate_lookup_table();
        }

        private byte[] generate_all_bytes() {
            byte[] bytes = new byte[256];
            byte b = 0;
            while(true) {
                bytes[b] = b;
                if (b == 255) {
                    break;
                }

                b++;
            }
            return bytes;
        }

        private void calculate_lookup_table() {
            IO.ThreadInfo[] thread_infos = IO.calculate_thread_info(256, thread_count);
            Thread[] threads = new Thread[thread_infos.Length];

            byte[] bytes = generate_all_bytes();

            for (int i = 0 ; i < thread_infos.Length ; i++) {
                IO.ThreadInfo info = thread_infos[i];
                info.id = i;
                threads[i] = new Thread(() => {
                    long end_pos = info.lenght + info.offset;

                    for (long pos = info.offset ; pos < end_pos ; pos++) {
                        lookup_table[pos] = polynomial_divide(bytes[pos]);
                    }
                });

                threads[i].Start();
            }

            foreach (Thread thread in threads) {
                thread.Join();
            }
        }

        public ulong polynomial_divide(byte data) {
            string binary_data_string = Convert.ToString(data, 2);
            binary_data_string = binary_data_string.PadLeft(8, '0'); // 8 karaktera
            int data_lenght_before_right_padding = binary_data_string.Length;

            binary_data_string = binary_data_string.PadRight(padding_lenght + data_lenght_before_right_padding, '0'); // crc dopisivanje nula
            
            BitArray data_bits = new BitArray(binary_data_string.Select(i => i == '1').ToArray());
            
            // crc deljenje
            for (int i = 0 ; i < data_lenght_before_right_padding ; i++) {
                // ako je neki bit, s leva na desno, jednak jedinici tada delimo
                if (data_bits[i] == true) {
                    for (int j = 0 ; j < polynomial_length ; j++) {
                        data_bits[i + j] ^= polynomial[j];
                    }
                }
            }

            string divided_bits_string = "";
            foreach (bool bit in data_bits) {
                divided_bits_string += (bit == true) ? '1' : '0';
            }

            divided_bits_string = Tools.GetLast(divided_bits_string, padding_lenght);
            ulong result = binary_string_to_ulong(divided_bits_string);

            return result;

        }

        private ulong Checksum(byte[] input) {
            if (input == null) { throw new ArgumentNullException("Input is null"); }

            ulong result = 0;
            for (int i = 0 ; i < input.Length ; i++) {
                result = result ^ lookup_table[input[i]];
            }

            return result;
        }

        // visenitno racunanje checksum-a iz niza byte-ova
        public ulong ChecksumFile(byte[] input) {
            if (input.Length == 0) { throw new Exception("No data"); }

            IO.ThreadInfo[] thread_infos = IO.calculate_thread_info(input.LongLength, thread_count);
            Thread[] threads = new Thread[thread_infos.Length];
            ulong[] thread_checksums = new ulong[thread_infos.Length];

            for (int i = 0 ; i < thread_infos.Length ; i++) {
                IO.ThreadInfo info = thread_infos[i];
                info.id = i;
                threads[i] = new Thread(() => {
                    ulong thread_checksum = 0;
                    long end_pos = info.lenght + info.offset;

                    for (long pos = info.offset ; pos < end_pos ; pos++) {
                        thread_checksum = thread_checksum ^ lookup_table[input[pos]];
                    }

                    thread_checksums[info.id] = thread_checksum;
                });
                threads[i].Start();
            }

            ulong checksum = 0;
            foreach (Thread thread in threads) { thread.Join(); }
            foreach (ulong thread_checksum in thread_checksums) {
                checksum = checksum ^ thread_checksum;
            }

            return checksum;
        }

        // visenitno racunanje checksum-a iz filepath-a
        public ulong ChecksumFile(string inputpath) {
            IO.valid_filepath(inputpath);

            ulong checksum = 0;
            using(FileStream filestream = new FileStream(inputpath, FileMode.Open, FileAccess.Read)) {
                
                byte[] buffer = new byte[128 * 1024 * 1024]; // 128 MB BUFFER
                int bytes_read = filestream.Read(buffer, 0, buffer.Length);
                while (bytes_read > 0) {
                    
                    // obrada
                    IO.ThreadInfo[] thread_infos = IO.calculate_thread_info(bytes_read, thread_count);
                    Thread[] threads = new Thread[thread_infos.Length];
                    ulong[] thread_checksums = new ulong[thread_infos.Length];

                    for (int i = 0 ; i < thread_infos.Length ; i++) {
                        IO.ThreadInfo info = thread_infos[i];
                        info.id = i;
                        threads[i] = new Thread(() => {
                            ulong thread_checksum = 0;
                            long end_pos = info.lenght + info.offset;

                            for (long pos = info.offset ; pos < end_pos ; pos++) {
                                thread_checksum = thread_checksum ^ lookup_table[buffer[pos]];
                            }

                            thread_checksums[info.id] = thread_checksum;
                        });
                        threads[i].Start();
                    }

                    foreach (Thread thread in threads) { thread.Join(); }
                    foreach (ulong thread_checksum in thread_checksums) {
                        checksum = checksum ^ thread_checksum;
                    }
                    
                    bytes_read = filestream.Read(buffer, 0, buffer.Length);
                    // kada read funckija cita poslednji blok podataka koji je manji od buffer-a
                    // ona ne stavlja ostatak buffer-a na nulu
                    long remanining_bytes = buffer.LongLength - bytes_read;
                    if (remanining_bytes > 0) {
                        Array.Clear(buffer, bytes_read, (int)remanining_bytes);
                    }

                }

            }

            return checksum;
        }

        public ulong ChecksumTextFile(string[] input) {
            if (input == null) { throw new Exception("Input string array is null"); }
            if (input.Length == 0) { throw new Exception("No data"); }

            ulong[] results = input.Select(i => ChecksumPlaintext(i)).ToArray();
            ulong result = 0;
            foreach (ulong r in results) {
                result = result ^ r;
            }
            return result;
        }
        public ulong ChecksumTextFile(string inputpath) {
            string[] input_strings = IO.OpenTextFile(inputpath);
            if (input_strings.Length == 0) { throw new Exception("No data"); }
            return ChecksumTextFile(input_strings);
        }

        public ulong ChecksumPlaintext(string plaintext) {
            byte[] plaintext_bytes = Convertor.string_to_bytes(plaintext);
            return Checksum(plaintext_bytes);
        }
    }
}
