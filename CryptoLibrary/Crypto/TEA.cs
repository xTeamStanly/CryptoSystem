using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Crypto {
    public class TEA : ICipher, ICipherReference {
        private readonly static uint delta_const = 0x9E3779B9;
        private readonly static uint sum_const = 0xC6EF3720; // (delta_const << 5) & 0xFFFFFFFF

        private uint[] key;
        public uint[] Key { get { return key; } }

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

        private static uint padding_calculation(int lenght, int padding) {
            padding = Math.Abs(padding);

            int number_of_missing_elements = (padding - lenght % padding) % padding;
            return Convert.ToUInt32(number_of_missing_elements);
        }
        private static uint[] byte_array_to_unsigned_array_with_end_padding(byte[] bytes, int padding_size) {
            if (bytes == null) { throw new ArgumentNullException("Input byte array is null"); }

            int bytes_lenght = bytes.Length;
            if (bytes_lenght == 0) { return new uint[0]; }

            // byte -> uint padding (fali byte: 0x12 0x13 0x14 -> UINT)
            uint byte_padding = padding_calculation(bytes_lenght, 4);
            if (byte_padding  != 0) {
                byte[] new_bytes = new byte[bytes_lenght + byte_padding];
                Array.Copy(bytes, new_bytes, bytes_lenght);
                bytes = new_bytes;
            }

            List<uint> result = new List<uint>();
            for (int i = 0 ; i < bytes_lenght ; i += 4) {
                uint value = BitConverter.ToUInt32(new byte[] { bytes[i], bytes[i + 1], bytes[i + 2], bytes[i + 3] }, 0);
                result.Add(value);
            }

            // uint padding
            uint uint_padding = padding_calculation(result.Count, padding_size);
            for (int i = 0 ; i < uint_padding ; i++) { result.Add(0); }

            // koliki je bio ukupan padding u bajtovima: byte_padding + 4 * uint_padding
            // upisujemo ovaj padding kao uint na kraju podataka
            uint final_byte_padding = byte_padding + (uint_padding + Convert.ToUInt32(padding_size)) * 4;
            // ubacujemo dva puta zbog bloka
            for (int i = 0 ; i < padding_size ; i++) { result.Add(final_byte_padding); }

            return result.ToArray();
        }
        private static uint[] byte_array_to_unsigned_array(byte[] bytes, int padding_size) {
            if (bytes == null) { throw new ArgumentNullException("Input byte array is null"); }

            int bytes_lenght = bytes.Length;
            if (bytes_lenght == 0) { return new uint[0]; }

            uint byte_padding = padding_calculation(bytes_lenght, 4);
            if (byte_padding  != 0) {
                byte[] new_bytes = new byte[bytes_lenght + byte_padding];
                Array.Copy(bytes, new_bytes, bytes_lenght);
                bytes = new_bytes;
            }

            List<uint> result = new List<uint>();
            for (int i = 0 ; i < bytes_lenght ; i += 4) {
                uint value = BitConverter.ToUInt32(new byte[] { bytes[i], bytes[i + 1], bytes[i + 2], bytes[i + 3] }, 0);
                result.Add(value);
            }

            uint uint_padding = padding_calculation(result.Count, padding_size);
            for (int i = 0 ; i < uint_padding ; i++) { result.Add(0); }

            return result.ToArray();
        }
        private static byte[] unsigned_array_to_byte_array_remove_padding(uint[] input) {
            uint last_uint = input[input.Length - 1];

            byte[] input_bytes = unsigned_array_to_byte_array(input);
            byte[] result_bytes = new byte[input_bytes.Length - last_uint];
            Array.Copy(input_bytes, result_bytes, result_bytes.Length);

            return result_bytes;
        }
        private static byte[] unsigned_array_to_byte_array(uint[] input) {
            if (input == null) { throw new ArgumentNullException("Uint array is null"); }

            int input_lenght = input.Length;
            if (input_lenght == 0) { return new byte[0]; }

            byte[] bytes = new byte[4 * input_lenght];
            for (int i = 0 ; i < input_lenght ; i++) {
                int index = i * 4;

                byte[] bytes_from_uint = unsigned_to_bytes(input[i]);

                bytes[index] = bytes_from_uint[0];
                bytes[index + 1] = bytes_from_uint[1];
                bytes[index + 2] = bytes_from_uint[2];
                bytes[index + 3] = bytes_from_uint[3];

            }
            return bytes;
        }
        private static byte[] unsigned_to_bytes(uint input) {
            byte[] bytes = new byte[4];
            bytes[0] = (byte)(input         & 0xFF);
            bytes[1] = (byte)((input >> 8)  & 0xFF);
            bytes[2] = (byte)((input >> 16) & 0xFF);
            bytes[3] = (byte)((input >> 24) & 0xFF);
            return bytes;
        }

        public TEA(string unicode_key) {
            if (unicode_key == null) { throw new ArgumentNullException("Key is null"); }

            // 128b = char (8b) * 16
            if (unicode_key.Length != 16) { throw new ArgumentException("Key lenght is not valid");}

            key = unicode_key_to_unsigned_key(unicode_key);
        }

        private void encrypt_one_cycle(uint[] v) {
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
        private void decrypt_one_cycle(uint[] v) {
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
            uint[] data = byte_array_to_unsigned_array_with_end_padding(input, 2);
            Encrypt(ref data);
            return unsigned_array_to_byte_array(data);
        }
        public byte[] DecryptFile(byte[] input) {
            uint[] data = byte_array_to_unsigned_array(input, 2);
            Decrypt(ref data);
            return unsigned_array_to_byte_array_remove_padding(data);
        }
        public void EncryptFile(string inputpath, string outputpath) {
            byte[] input_bytes = IO.OpenFile(inputpath);
            byte[] output_bytes = EncryptFile(input_bytes);
            IO.SaveFile(outputpath, output_bytes);
        }
        public void DecryptFile(string inputpath, string outputpath) {
            byte[] input_bytes = IO.OpenFile(inputpath);
            byte[] output_bytes = DecryptFile(input_bytes);
            IO.SaveFile(outputpath, output_bytes);
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
            byte[] output_bytes = EncryptBitmap(input_bytes);
            IO.SaveFile(outputpath, output_bytes);
        }
        public void DecryptBitmap(string inputpath, string outputpath) {
            byte[] input_bytes = IO.OpenFile(inputpath);
            byte[] output_bytes = DecryptBitmap(input_bytes);
            IO.SaveFile(outputpath, output_bytes);
        }

        public string[] EncryptText(string[] input) {
            if (input == null) { throw new Exception("Input string array is null"); }
            return input.Select(i => EncryptPlaintext(i)).ToArray();
        }
        public string[] DecryptText(string[] input) {
            if (input == null) { throw new Exception("Input string array is null"); }
            return input.Select(i => DecryptPlaintext(i)).ToArray();
        }
        public void DecryptText(string inputpath, string outputpath) {
            string[] input_strings = IO.OpenTextFile(inputpath);
            string[] output_strings = EncryptText(input_strings);
            IO.SaveTextFile(outputpath, output_strings);
        }
        public void EncryptText(string inputpath, string outputpath) {
            string[] input_strings = IO.OpenTextFile(inputpath);
            string[] output_strings = DecryptText(input_strings);
            IO.SaveTextFile(outputpath, output_strings);
        }

        public string EncryptPlaintext(string input) {
            byte[] input_bytes = Convertor.string_to_bytes(input);
            byte[] output_bytes = EncryptFile(input_bytes);
            return Convertor.bytes_to_string(output_bytes);
        }
        public string DecryptPlaintext(string input) {
            byte[] input_bytes = Convertor.string_to_bytes(input);
            byte[] output_bytes = DecryptFile(input_bytes);
            return Convertor.bytes_to_string(output_bytes);
        }
    }
}
