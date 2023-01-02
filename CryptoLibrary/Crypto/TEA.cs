using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Crypto {
    // fajlovi nisu kompatibilni sa TEAThreaded, vec se koristi samo za CBC(TEA)
    internal class TEA {
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

        public TEA(string unicode_key) {
            if (unicode_key == null) { throw new ArgumentNullException("Key is null"); }

            // 128b = char (8b) * 16
            if (unicode_key.Length != 16) { throw new ArgumentException("Key lenght is not valid");}

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
            uint[] data = Convertor.byte_array_to_unsigned_array_with_end_padding(input, 2);
            if (data.Length == 0) { throw new Exception("No data"); }
            
            Encrypt(ref data);
            return Convertor.unsigned_array_to_byte_array(data);
        }
        public byte[] DecryptFile(byte[] input) {
            uint[] data = Convertor.byte_array_to_unsigned_array(input, 2);
            if (data.Length == 0) { throw new Exception("No data"); }
            
            Decrypt(ref data);
            return Convertor.unsigned_array_to_byte_array_remove_padding(data, 2);
        }
        public void EncryptFile(string inputpath, string outputpath) {
            byte[] input_bytes = IO.OpenFile(inputpath);
            if (input_bytes.Length == 0) { throw new Exception("No data"); }
            
            byte[] output_bytes = EncryptFile(input_bytes);
            IO.SaveFile(outputpath, output_bytes);
        }
        public void DecryptFile(string inputpath, string outputpath) {
            byte[] input_bytes = IO.OpenFile(inputpath);
            if (input_bytes.Length == 0) { throw new Exception("No data"); }
            
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
