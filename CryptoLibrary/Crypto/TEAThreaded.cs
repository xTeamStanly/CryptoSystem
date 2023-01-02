using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Crypto {
    public class TEAThreaded {
        private readonly static uint delta_const = 0x9E3779B9;
        private readonly static uint sum_const = 0xC6EF3720; // (delta_const << 5) & 0xFFFFFFFF

        private uint[] key;
        public uint[] Key { get { return key; } }

        private int thread_count = 1;

        private static uint[] unicode_key_to_unsigned_key(string unicode_key) {
            uint[] key = new uint[4];

            uint[] key_parts = Convertor.string_to_bytes(unicode_key).Select(i => (uint)i).ToArray();
            for (uint subkey_index = 0 ; subkey_index < 4 ; subkey_index++) {
                uint index = subkey_index * 4;

                uint subkey = 0;
                subkey += (key_parts[index]);
                subkey += (key_parts[index + 1] << 8);
                subkey += (key_parts[index + 2] << 16);
                subkey += (key_parts[index + 3] << 24);

                key[subkey_index] = subkey;
            }

            return key;
        }

        public TEAThreaded(string unicode_key) {
            if (unicode_key == null) { throw new ArgumentNullException("Key is null"); }

            // 128b = char (8b) * 16
            if (unicode_key.Length != 16) { throw new ArgumentException("Key lenght is not valid"); }

            key = unicode_key_to_unsigned_key(unicode_key);
        }

        public TEAThreaded(string unicode_key, int thread_count) {
            thread_count = Math.Abs(thread_count);
            if (thread_count == 0) {
                this.thread_count = 1;
            } else {
                this.thread_count = thread_count;
            }

            if (unicode_key == null) { throw new ArgumentNullException("Key is null"); }

            // 128b = char (8b) * 16
            if (unicode_key.Length != 16) { throw new ArgumentException("Key lenght is not valid"); }

            key = unicode_key_to_unsigned_key(unicode_key);
        }

        public void encrypt_one_cycle(uint[] v) {
            uint v0 = v[0];
            uint v1 = v[1];
            uint sum = 0;
            uint i;

            uint k0 = key[0];
            uint k1 = key[1];
            uint k2 = key[2];
            uint k3 = key[3];

            for (i = 0 ; i < 32 ; i++) {
                sum += delta_const;
                v0 += ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
                v1 += ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
            }

            v[0] = v0;
            v[1] = v1;
        }
        public void decrypt_one_cycle(uint[] v) {
            uint v0 = v[0];
            uint v1 = v[1];
            uint sum = sum_const;
            uint i;

            uint k0 = key[0];
            uint k1 = key[1];
            uint k2 = key[2];
            uint k3 = key[3];

            for (i = 0 ; i < 32 ; i++) {
                v1 -= ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
                v0 -= ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
                sum -= delta_const;
            }

            v[0] = v0;
            v[1] = v1;
        }

        public void Encrypt(ref uint[] input) {
            if (input == null) { throw new ArgumentNullException("Input uint array is null"); }

            for (int i = 0 ; i < input.Length ; i += 2) {
                uint[] arr = new uint[2];
                arr[0] = input[i];
                arr[1] = input[i + 1];

                encrypt_one_cycle(arr);

                input[i] = arr[0];
                input[i + 1] = arr[1];
            }
        }
        public void Decrypt(ref uint[] input) {
            if (input == null) { throw new Exception("Input uint array is null"); }

            for (int i = 0 ; i < input.Length ; i += 2) {
                uint[] arr = new uint[2];
                arr[0] = input[i];
                arr[1] = input[i + 1];

                decrypt_one_cycle(arr);

                input[i] = arr[0];
                input[i + 1] = arr[1];
            }
        }

        public byte[] EncryptFile(byte[] input) {
            if (input == null) { throw new ArgumentNullException("Input byte array is null"); }

            long full_block_count = input.LongLength / 8;
            long partial_block_size = input.LongLength % 8;

            byte[] output_bytes = new byte[full_block_count * 8 + ((partial_block_size == 0) ? 0 : 8) + 4]; // 8 (parcijalni blok ako postoji) + 4 (padding vrednost)

            if (full_block_count != 0) {
                // postoje celi blokovi, normalna racunica

                long local_thread_count = thread_count;
                if (thread_count > full_block_count) { local_thread_count = 1; }

                long bytes_per_thread = (full_block_count / local_thread_count) * 8;

                IO.ThreadInfo[] thread_infos = new IO.ThreadInfo[local_thread_count];

                int i;
                for (i = 0 ; i < local_thread_count - 1 ; i++) {
                    thread_infos[i].id = i;
                    thread_infos[i].offset = i * bytes_per_thread;
                    thread_infos[i].lenght = bytes_per_thread;
                }

                long last_thread_byte_count = bytes_per_thread + (full_block_count % local_thread_count) * 8;
                thread_infos[i].id = i;
                thread_infos[i].offset = i * bytes_per_thread;
                thread_infos[i].lenght = last_thread_byte_count;

                Thread[] threads = new Thread[thread_infos.Length];
                for (i = 0 ; i < thread_infos.Length ; i++) {

                    int thread_i = i;
                    threads[i] = new Thread(() => {
                        IO.ThreadInfo info = thread_infos[thread_i];

                        byte[] thread_bytes = new byte[info.lenght];
                        Array.Copy(input, info.offset, thread_bytes, 0, info.lenght);

                        uint[] thread_result = Convertor.byte_array_to_unsigned_array_no_padding(thread_bytes);
                        Encrypt(ref thread_result);

                        thread_bytes = Convertor.unsigned_array_to_byte_array(thread_result);
                        Array.Copy(thread_bytes, 0, output_bytes, info.offset, info.lenght);

                    });
                    threads[i].Start();
                }
                foreach (Thread thread in threads) { thread.Join(); }
            }

            uint padding_lenght = 0;
            if (partial_block_size != 0) {
                // poslednji deo koji nema padding, dugacak je izmedju 1 i 7 bajtova
                padding_lenght = Convertor.padding_calculation((int)partial_block_size, 8);

                long padding_offset = full_block_count * 8;
                byte[] padded_bytes = new byte[8];
                Array.Copy(input, padding_offset, padded_bytes, 0, partial_block_size);

                uint[] padded_result = Convertor.byte_array_to_unsigned_array_no_padding(padded_bytes);
                Encrypt(ref padded_result);

                padded_bytes = Convertor.unsigned_array_to_byte_array(padded_result);

                Array.Copy(padded_bytes, 0, output_bytes, full_block_count * 8, 8);
            }
            byte[] padding_lenght_bytes = Convertor.unsigned_to_bytes(padding_lenght);

            Array.Copy(padding_lenght_bytes, 0, output_bytes, full_block_count * 8 + ((partial_block_size == 0) ? 0 : 8), 4);
            return output_bytes;
        }
        public byte[] DecryptFile(byte[] input) {
            if (input == null) { throw new ArgumentNullException("Input byte array is null"); }

            long full_block_count = input.LongLength / 8;

            byte[] padding_bytes = new byte[4];
            Array.Copy(input, input.Length - 4, padding_bytes, 0, 4);
            uint padding_lenght = Convertor.byte_array_to_unsigned(padding_bytes);
            Array.Resize(ref input, (int)input.LongLength - 4);

            long local_thread_count = thread_count;
            if (thread_count > full_block_count) { local_thread_count = 1; }

            long bytes_per_thread = (full_block_count / local_thread_count) * 8;

            IO.ThreadInfo[] thread_infos = new IO.ThreadInfo[local_thread_count];

            int i;
            for (i = 0 ; i < local_thread_count - 1 ; i++) {
                thread_infos[i].id = i;
                thread_infos[i].offset = i * bytes_per_thread;
                thread_infos[i].lenght = bytes_per_thread;
            }

            long last_thread_byte_count = bytes_per_thread + (full_block_count % local_thread_count) * 8;
            thread_infos[i].id = i;
            thread_infos[i].offset = i * bytes_per_thread;
            thread_infos[i].lenght = last_thread_byte_count;

            byte[] output_bytes = new byte[full_block_count * 8];
            Thread[] threads = new Thread[thread_infos.Length];
            for (i = 0 ; i < thread_infos.Length ; i++) {

                int thread_i = i;
                threads[i] = new Thread(() => {
                    IO.ThreadInfo info = thread_infos[thread_i];

                    byte[] thread_bytes = new byte[info.lenght];
                    Array.Copy(input, info.offset, thread_bytes, 0, info.lenght);

                    uint[] thread_result = Convertor.byte_array_to_unsigned_array_no_padding(thread_bytes);
                    Decrypt(ref thread_result);

                    thread_bytes = Convertor.unsigned_array_to_byte_array(thread_result);
                    Array.Copy(thread_bytes, 0, output_bytes, info.offset, info.lenght);

                });
                threads[i].Start();
            }

            foreach (Thread thread in threads) { thread.Join(); }

            Array.Resize(ref output_bytes, (int)output_bytes.LongLength - (int)padding_lenght);
            return output_bytes;
        }

        public void EncryptFile(string inputpath, string outputpath) {
            IO.valid_filepath(inputpath);
            IO.valid_filepath(outputpath);

            using(FileStream input = new FileStream(inputpath, FileMode.Open, FileAccess.Read)) {
                using (FileStream output = File.Create(outputpath)) {

                    byte[] buffer = new byte[128 * 1024 * 1024]; // 128 MB BUFFER
                    int bytes_read = input.Read(buffer, 0, buffer.Length);

                    while (bytes_read > 0) {
                        
                        if (bytes_read != buffer.Length) {
                            // zadnji chunk, padding racunica

                            byte[] input_bytes = new byte[bytes_read];
                            Array.Copy(buffer, input_bytes, bytes_read);

                            long full_block_count = input_bytes.LongLength / 8;
                            long partial_block_size = input_bytes.LongLength % 8;

                            if (full_block_count != 0) {
                                // postoje celi blokovi, normalna racunica

                                long local_thread_count = thread_count;
                                if (thread_count > full_block_count) { local_thread_count = 1; }

                                long bytes_per_thread = (full_block_count / local_thread_count) * 8;
                                
                                IO.ThreadInfo[] thread_infos = new IO.ThreadInfo[local_thread_count];

                                int i;
                                for (i = 0 ; i < local_thread_count - 1 ; i++) {
                                    thread_infos[i].id = i;
                                    thread_infos[i].offset = i * bytes_per_thread;
                                    thread_infos[i].lenght = bytes_per_thread;
                                }

                                long last_thread_byte_count = bytes_per_thread + (full_block_count % local_thread_count) * 8;
                                thread_infos[i].id = i;
                                thread_infos[i].offset = i * bytes_per_thread;
                                thread_infos[i].lenght = last_thread_byte_count;

                                byte[] output_bytes = new byte[full_block_count * 8];
                                Thread[] threads = new Thread[thread_infos.Length];
                                for (i = 0 ; i < thread_infos.Length ; i++) {

                                    int thread_i = i;
                                    threads[i] = new Thread(() => {
                                        IO.ThreadInfo info = thread_infos[thread_i];

                                        byte[] thread_bytes = new byte[info.lenght];
                                        Array.Copy(input_bytes, info.offset, thread_bytes, 0, info.lenght);

                                        uint[] thread_result = Convertor.byte_array_to_unsigned_array_no_padding(thread_bytes);
                                        Encrypt(ref thread_result);

                                        thread_bytes = Convertor.unsigned_array_to_byte_array(thread_result);
                                        Array.Copy(thread_bytes, 0, output_bytes, info.offset, info.lenght);

                                    });
                                    threads[i].Start();
                                }
                                foreach (Thread thread in threads) { thread.Join(); }
                                output.Write(output_bytes, 0, output_bytes.Length);
                            }

                            uint padding_lenght = 0;
                            if (partial_block_size != 0) {
                                // poslednji deo koji nema padding, dugacak je izmedju 1 i 7 bajtova
                                padding_lenght = Convertor.padding_calculation((int)partial_block_size, 8);

                                long padding_offset = full_block_count * 8;
                                byte[] padded_bytes = new byte[8];
                                Array.Copy(input_bytes, padding_offset, padded_bytes, 0, partial_block_size);

                                uint[] padded_result = Convertor.byte_array_to_unsigned_array_no_padding(padded_bytes);
                                Encrypt(ref padded_result);

                                padded_bytes = Convertor.unsigned_array_to_byte_array(padded_result);
                                output.Write(padded_bytes, 0, padded_bytes.Length);
                            }
                            byte[] padding_lenght_bytes = Convertor.unsigned_to_bytes(padding_lenght);
                            output.Write(padding_lenght_bytes, 0, padding_lenght_bytes.Length);

                        } else {
                            // nije poslednji chunk, normalna racunica
                            // podaci su vec podeljeni u cele blokove

                            long number_of_block = buffer.LongLength / 8;
                            long blocks_per_thread = number_of_block / thread_count;
                            long bytes_per_thread = 8 * blocks_per_thread;
                            IO.ThreadInfo[] thread_infos = new IO.ThreadInfo[thread_count];
                            for (int i = 0 ; i < thread_infos.Length ; i++) {
                                thread_infos[i].id = i;
                                thread_infos[i].offset = i * bytes_per_thread; // offset u byte-ovima
                                thread_infos[i].lenght = bytes_per_thread; // duzina u byte-ovima
                            }

                            byte[] output_bytes = new byte[buffer.LongLength];
                            Thread[] threads = new Thread[thread_infos.Length];
                            for (int i = 0 ; i < thread_infos.Length ; i++) {
                                
                                int thread_i = i; // closure backup
                                threads[i] = new Thread(() => {
                                    IO.ThreadInfo info = thread_infos[thread_i];
                                    
                                    byte[] thread_bytes = new byte[info.lenght];
                                    Array.Copy(buffer, info.offset, thread_bytes, 0, info.lenght);

                                    uint[] thread_result = Convertor.byte_array_to_unsigned_array_no_padding(thread_bytes);
                                    Encrypt(ref thread_result);

                                    thread_bytes = Convertor.unsigned_array_to_byte_array(thread_result);
                                    Array.Copy(thread_bytes, 0, output_bytes, info.offset, info.lenght);
                                });
                                threads[i].Start();
                            }

                            foreach (Thread thread in threads) { thread.Join(); }
                            output.Write(output_bytes, 0, output_bytes.Length);
                        }

                        bytes_read = input.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
        public void DecryptFile(string inputpath, string outputpath) {
            IO.valid_filepath(inputpath);
            IO.valid_filepath(outputpath);

            using (FileStream input = new FileStream(inputpath, FileMode.Open, FileAccess.Read)) {
                using (FileStream output = File.Create(outputpath)) {

                    byte[] buffer = new byte[128 * 1024 * 1024]; // 128 MB BUFFER
                    int bytes_read = input.Read(buffer, 0, buffer.Length);

                    while (bytes_read > 0) {
                    
                        if (bytes_read != buffer.Length) {
                            // zadnji chuck, padding racunica

                            byte[] input_bytes = new byte[bytes_read];
                            Array.Copy(buffer, input_bytes, bytes_read);

                            long full_block_count = input_bytes.LongLength / 8;

                            long current_input_position = input.Position;
                            input.Seek(-4, SeekOrigin.End); // znamo da su poslednja 8 bajta sigurno padding
                            byte[] padding_bytes = new byte[4];
                            input.Read(padding_bytes, 0, 4);
                            uint padding_lenght = Convertor.byte_array_to_unsigned(padding_bytes);
                            Array.Resize(ref input_bytes, (int)input_bytes.LongLength - 4);

                            input.Position = current_input_position;

                            if (full_block_count != 0) {
                                // postoje celi blokovi, normalna racunica

                                long local_thread_count = thread_count;
                                if (thread_count > full_block_count) { local_thread_count = 1; }

                                long bytes_per_thread = (full_block_count / local_thread_count) * 8;

                                IO.ThreadInfo[] thread_infos = new IO.ThreadInfo[local_thread_count];

                                int i;
                                for (i = 0 ; i < local_thread_count - 1; i++) {
                                    thread_infos[i].id = i;
                                    thread_infos[i].offset = i * bytes_per_thread;
                                    thread_infos[i].lenght = bytes_per_thread;
                                }

                                long last_thread_byte_count = bytes_per_thread + (full_block_count % local_thread_count) * 8;
                                thread_infos[i].id = i;
                                thread_infos[i].offset = i * bytes_per_thread;
                                thread_infos[i].lenght = last_thread_byte_count;

                                byte[] output_bytes = new byte[full_block_count * 8];
                                Thread[] threads = new Thread[thread_infos.Length];
                                for (i = 0 ; i < thread_infos.Length ; i++) {

                                    int thread_i = i;
                                    threads[i] = new Thread(() => {
                                        IO.ThreadInfo info = thread_infos[thread_i];

                                        byte[] thread_bytes = new byte[info.lenght];
                                        Array.Copy(input_bytes, info.offset, thread_bytes, 0, info.lenght);

                                        uint[] thread_result = Convertor.byte_array_to_unsigned_array_no_padding(thread_bytes);
                                        Decrypt(ref thread_result);

                                        thread_bytes = Convertor.unsigned_array_to_byte_array(thread_result);
                                        Array.Copy(thread_bytes, 0, output_bytes, info.offset, info.lenght);

                                    });
                                    threads[i].Start();
                                }

                                foreach (Thread thread in threads) { thread.Join(); }

                                Array.Resize(ref output_bytes, (int)output_bytes.LongLength - (int)padding_lenght);
                                output.Write(output_bytes, 0, output_bytes.Length);
                            }

                        } else {
                            // nije poslednji chunk, normalna racunica
                            // podaci su vec podeljeni u cele blokove

                            long number_of_block = buffer.LongLength / 8;
                            long blocks_per_thread = number_of_block / thread_count;
                            long bytes_per_thread = 8 * blocks_per_thread;
                            IO.ThreadInfo[] thread_infos = new IO.ThreadInfo[thread_count];
                            for (int i = 0 ; i < thread_infos.Length ; i++) {
                                thread_infos[i].id = i;
                                thread_infos[i].offset = i * bytes_per_thread; // offset u byte-ovima
                                thread_infos[i].lenght = bytes_per_thread; // duzina u byte-ovima
                            }

                            byte[] output_bytes = new byte[buffer.LongLength];
                            Thread[] threads = new Thread[thread_infos.Length];
                            for (int i = 0 ; i < thread_infos.Length ; i++) {

                                int thread_i = i; // closure backup
                                threads[i] = new Thread(() => {
                                    IO.ThreadInfo info = thread_infos[thread_i];

                                    byte[] thread_bytes = new byte[info.lenght];
                                    Array.Copy(buffer, info.offset, thread_bytes, 0, info.lenght);

                                    uint[] thread_result = Convertor.byte_array_to_unsigned_array_no_padding(thread_bytes);
                                    Decrypt(ref thread_result);

                                    thread_bytes = Convertor.unsigned_array_to_byte_array(thread_result);
                                    Array.Copy(thread_bytes, 0, output_bytes, info.offset, info.lenght);
                                });
                                threads[i].Start();
                            }

                            foreach (Thread thread in threads) { thread.Join(); }
                            output.Write(output_bytes, 0, output_bytes.Length);
                        }

                        bytes_read = input.Read(buffer, 0, buffer.Length);
                    }


                }
            }
        }

        public byte[] EncryptBitmap(byte[] input) {
            if (input == null) { throw new Exception("Input byte array is null"); }

            int input_lenght = input.Length;
            if (input.Length == 0) { throw new Exception("Input byte array is empty"); }

            int end_of_header_position = input[10] + 256 * (input[11] + 256 * (input[12] + 256 * input[13]));

            byte[] input_pixels = new byte[input_lenght - end_of_header_position];
            Array.Copy(input, end_of_header_position, input_pixels, 0, input_pixels.Length);

            input_pixels = EncryptFile(input_pixels);

            byte[] output = new byte[end_of_header_position + input_pixels.Length];
            Array.Copy(input, 0, output, 0, end_of_header_position);
            Array.Copy(input_pixels, 0, output, end_of_header_position, input_pixels.Length);

            return output;
        }
        public byte[] DecryptBitmap(byte[] input) {
            if (input == null) { throw new Exception("Input byte array is null"); }

            int input_lenght = input.Length;
            if (input.Length == 0) { throw new Exception("Input byte array is empty"); }

            int end_of_header_position = input[10] + 256 * (input[11] + 256 * (input[12] + 256 * input[13]));

            byte[] input_pixels = new byte[input_lenght - end_of_header_position];
            Array.Copy(input, end_of_header_position, input_pixels, 0, input_pixels.Length);

            input_pixels = DecryptFile(input_pixels);

            byte[] output = new byte[end_of_header_position + input_pixels.Length];
            Array.Copy(input, 0, output, 0, end_of_header_position);
            Array.Copy(input_pixels, 0, output, end_of_header_position, input_pixels.Length);

            return output;
        }
        public void EncryptBitmap(string inputpath, string outputpath) {
            byte[] input_bytes = IO.OpenFile(inputpath);
            if (input_bytes.Length == 0) { throw new Exception("No data"); }

            byte[] output_bytes = EncryptBitmap(input_bytes);
            IO.SaveFile(outputpath, output_bytes);
        }
        public void DecryptBitmap(string inputpath, string outputpath) {
            byte[] input_bytes = IO.OpenFile(inputpath);
            if (input_bytes.Length == 0) { throw new Exception("No data"); }

            byte[] output_bytes = DecryptBitmap(input_bytes);
            IO.SaveFile(outputpath, output_bytes);
        }
    }
}
