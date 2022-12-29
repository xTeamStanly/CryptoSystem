using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Crypto {
    public class CBCTEA : ICipher, ICipherReference {
        private TEA tea = null;
        private uint[] initialization_vector = null;
        private uint[] IV_key = null;

        public CBCTEA(string tea_key, string initialization_vector) {
            tea = new TEA(tea_key);

            byte[] iv_bytes = Convertor.string_to_bytes(initialization_vector);
            this.initialization_vector = Convertor.byte_array_to_unsigned_array(iv_bytes, 2);

            IV_key = new uint[2];
        }

        public void Encrypt(ref uint[] input) {
            if (input == null) { throw new ArgumentNullException("Input uint array is null"); }

            // CBCTEA pocetno stanje
            Array.Copy(initialization_vector, IV_key, 2);

            // CBCTEA jedna runda
            for (int i = 0 ; i < input.Length ; i += 2) {
                uint[] arr = new uint[2];
                arr[0] = input[i] ^ IV_key[0];
                arr[1] = input[i + 1] ^ IV_key[1];

                tea.encrypt_one_cycle(arr);

                input[i] = arr[0];
                input[i + 1] = arr[1];

                Array.Copy(arr, IV_key, 2);
            }
        }
        public void Decrypt(ref uint[] input) {
            if (input == null) { throw new Exception("Input uint array is null"); }
;
            Array.Copy(initialization_vector, IV_key, 2);

            for (int i = 0 ; i < input.Length ; i += 2) {
                uint[] arr = new uint[2];
                arr[0] = input[i];
                arr[1] = input[i + 1];

                uint[] input_copy = new uint[2];
                Array.Copy(arr, input_copy, 2);

                tea.decrypt_one_cycle(arr);

                input[i] = arr[0] ^ IV_key[0];
                input[i + 1] = arr[1] ^ IV_key[1];

                Array.Copy(input_copy, IV_key, 2);
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

        public string[] EncryptText(string[] input) {
            if (input == null) { throw new Exception("Input string array is null"); }
            if (input.Length == 0) { throw new Exception("No data"); }

            return input.Select(i => EncryptPlaintext(i)).ToArray();
        }
        public string[] DecryptText(string[] input) {
            if (input == null) { throw new Exception("Input string array is null"); }
            if (input.Length == 0) { throw new Exception("No data"); }

            return input.Select(i => DecryptPlaintext(i)).ToArray();
        }
        public void EncryptText(string inputpath, string outputpath) {
            string[] input_strings = IO.OpenTextFile(inputpath);
            if (input_strings.Length == 0) { throw new Exception("No data"); }

            string[] output_strings = EncryptText(input_strings);
            IO.SaveTextFile(outputpath, output_strings);
        }
        public void DecryptText(string inputpath, string outputpath) {
            string[] input_strings = IO.OpenTextFile(inputpath);
            if (input_strings.Length == 0) { throw new Exception("No data"); }

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
