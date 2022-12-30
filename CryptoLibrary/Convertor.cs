using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library {
    public static class Convertor {

        public static byte[] string_to_bytes(string unicode_input) {
            if (unicode_input == null) { throw new ArgumentNullException("Unicode input is null"); }
            return unicode_input.Select(i => (byte)i).ToArray();
        }
        public static string bytes_to_string(byte[] input_bytes) {
            if (input_bytes == null) { throw new ArgumentNullException("Input byte array is null"); }
            return String.Join("", input_bytes.Select(i => (char)i));
        }

        private static uint padding_calculation(int lenght, int padding) {
            padding = Math.Abs(padding);

            int number_of_missing_elements = (padding - lenght % padding) % padding;
            return Convert.ToUInt32(number_of_missing_elements);
        }
        public static uint[] byte_array_to_unsigned_array_with_end_padding(byte[] bytes, int padding_size) {
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
        public static uint[] byte_array_to_unsigned_array(byte[] bytes, int padding_size) {
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
        public static byte[] unsigned_array_to_byte_array_remove_padding(uint[] input, int padding_size) {
            if (input.Length == 0) { return new byte[0]; }

            padding_size = Math.Abs(padding_size);
            uint pad_size = Convert.ToUInt32(padding_size);
            uint max_padding_size = 3 + (pad_size - 1 + pad_size) * 4;

            uint last_uint = input[input.Length - 1];
            if (last_uint > max_padding_size) { throw new Exception("Invalid padding size"); }


            byte[] input_bytes = unsigned_array_to_byte_array(input);
            byte[] result_bytes = new byte[input_bytes.Length - last_uint];
            Array.Copy(input_bytes, result_bytes, result_bytes.Length);

            return result_bytes;
        }
        public static byte[] unsigned_array_to_byte_array(uint[] input) {
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
        public static byte[] unsigned_to_bytes(uint input) {
            byte[] bytes = new byte[4];
            bytes[0] = (byte)(input         & 0xFF);
            bytes[1] = (byte)((input >> 8)  & 0xFF);
            bytes[2] = (byte)((input >> 16) & 0xFF);
            bytes[3] = (byte)((input >> 24) & 0xFF);
            return bytes;
        }
    }
}
