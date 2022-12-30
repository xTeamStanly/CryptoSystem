using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CryptoLibrary {
    public static class Utility {

        // rc4
        public static void valid_bytes(byte[] input) {
            if (input == null) { throw new ArgumentException("byte array is null"); }

            int input_lenght = input.Length;
            if (input_lenght < 1) { throw new ArgumentException("empty bytes"); }
        }
        public static void valid_unicode(string input) {
            if (input == null) { throw new ArgumentException("string is null"); }

            int input_lenght = input.Length;
            if (input_lenght < 1) { throw new ArgumentException("empty string"); }
        }

        // enigma
        public static string valid_rotor_configuration(string input) {
            if (input == null) { return null; }

            input = Regex.Replace(input, " ", "").ToLower();
            if (input.Length != 26) { return null; }

            HashSet<char> chars = new HashSet<char>();
            foreach (char c in input) {
                if (chars.Contains(c) == true) { return null; }
                chars.Add(c);
            }

            return input.ToUpper();
        }
        public static string inverse_rotor_configuration(string valid_rotor_configuration) {

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            char[] inverse_configuration = new char[26];
            for (int i = 0 ;i < 26 ;i++) {

                char rotor_letter = valid_rotor_configuration[i];
                int inverse_letter_position = alphabet.IndexOf(rotor_letter);

                inverse_configuration[inverse_letter_position] = alphabet[i];

            }

            return new string(inverse_configuration);
        }
        public static int valid_rotor_key(int input) {
            if (input < 1) { throw new ArgumentException("invalid starting position"); }
            return (input - 1) % 26;
        }

        public static int alphabet_letter_to_number(char letter) {
            bool small_letter = letter >= 'a' && letter <= 'z';
            bool big_letter = letter >= 'A' && letter <= 'Z';

            if (small_letter == false && big_letter == false) { return -1; }

            byte letter_byte = Encoding.UTF8.GetBytes(letter.ToString()).First();
            return letter_byte & 0b11111; // bitmask ascii/utf8 hack
        }
        public static string remove_all_whitespace_from_string(string input) {
            if (input == null) { return null; }
            input = Regex.Replace(input, " ", "");
            return input;
        }

        public static Dictionary<char, char> plug_board_configuration_string_to_dictionary(string configuration_string) {
            Dictionary<char, char> dictionary = new Dictionary<char, char>();

            if (configuration_string == null) { return dictionary; }

            configuration_string = configuration_string.ToUpper();
            configuration_string = Regex.Replace(configuration_string, " ", "");

            int configuration_string_lenght = configuration_string.Length;
            if (configuration_string_lenght % 2 == 1) {
                configuration_string.Remove(configuration_string_lenght - 1, 1);
            }

            configuration_string_lenght = configuration_string.Length;
            for (int i = 0 ;i < configuration_string_lenght ;i += 2) {
                char first = configuration_string[i];
                char second = configuration_string[i + 1];

                if (first == second) { continue; }
                if (dictionary.ContainsKey(first) == true || dictionary.ContainsKey(second) == true) { continue; }

                dictionary.Add(first, second);
                dictionary.Add(second, first);
            }

            return dictionary;
        }

        // tea
        public static uint[] unicode_to_tea_key(string input) {
            if (input == null) { throw new ArgumentNullException("invalid input"); }
            if (input.Length != 16) { throw new ArgumentNullException("invalid input"); }

            uint[] key = new uint[4];
            uint[] input_values = Encoding.UTF8.GetBytes(input).Select(i => (uint)i).ToArray();

            for (uint subkey_index = 0 ; subkey_index < 4 ; subkey_index++) {
                uint index = 4 * subkey_index;

                uint subkey = 0;
                subkey += (input_values[index]);
                subkey += (input_values[index + 1] << 8);
                subkey += (input_values[index + 2] << 16);
                subkey += (input_values[index + 3] << 24);

                key[subkey_index] = subkey;
            }

            return key;
        }

        // conversions
        public static byte[] get_bytes_from_unicode(string unicode_input) {
            if (unicode_input == null) { throw new ArgumentNullException("Invalid input"); }
             
            int unicode_input_lenght = unicode_input.Length;
            if (unicode_input_lenght < 1) { throw new ArgumentException("Invalid input"); }

            return unicode_input.Select(i => (byte)i).ToArray();

            // byte[] bytes = Encoding.UTF8.GetBytes(unicode_input);
            // return bytes;
        }
        public static string get_unicode_from_bytes(byte[] bytes_input) {
            if (bytes_input == null) { throw new ArgumentNullException("Invalid input"); }

            int bytes_input_lenght = bytes_input.Length;
            if (bytes_input_lenght < 1) { throw new ArgumentException("Invalid input"); }

            return String.Join("", bytes_input.Select(i => (char)i));

            // string unicode = Encoding.UTF8.GetString(bytes_input);
            // return unicode;
        }
        
        private static uint padding_calculation(int lenght, int padding) {
            padding = Math.Abs(padding);

            int number_of_missing_elements = (padding - lenght % padding) % padding;
            return Convert.ToUInt32(number_of_missing_elements);
        }
        public static uint[] byte_array_to_unsigned_array_with_end_padding(byte[] bytes, int padding_size) {   // PADDED BYTES
            if (bytes == null) { throw new ArgumentNullException("invalid input"); }
            
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

            // return bytes.Select(i => (uint)i).ToArray();
        }

        public static uint[] byte_array_to_unsigned_array(byte[] bytes, int padding_size) {   // PADDED BYTES
            if (bytes == null) { throw new ArgumentNullException("invalid input"); }

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
            for (int i = 0 ;i < bytes_lenght ;i += 4) {
                uint value = BitConverter.ToUInt32(new byte[] { bytes[i], bytes[i + 1], bytes[i + 2], bytes[i + 3] }, 0);
                result.Add(value);
            }

            // uint padding
            uint uint_padding = padding_calculation(result.Count, padding_size);
            for (int i = 0 ; i < uint_padding ; i++) { result.Add(0); }

            return result.ToArray();

            // return bytes.Select(i => (uint)i).ToArray();
        }
        public static byte[] unsigned_array_to_byte_array_remove_padding(uint[] input) {
            
            uint last_uint = input[input.Length - 1];
            
            byte[] input_bytes = unsigned_array_to_byte_array(input);

            byte[] result_bytes = new byte[input_bytes.Length - last_uint];

            Array.Copy(input_bytes, result_bytes, result_bytes.Length);

            return result_bytes;

        }

        public static byte[] unsigned_array_to_byte_array(uint[] input) {
            if (input == null) { throw new ArgumentNullException("invalid input"); }
            
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



        // TODO MORAM DA VIDIM STA CU SA OVIMA
        public static string unsigned_to_unicode_ignore_null_terminator(uint input) {
            string result = "";

            result += (char)(input & 0xFF);
            result += (char)((input >> 8) & 0xFF);
            result += (char)((input >> 16) & 0xFF);
            result += (char)((input >> 24) & 0xFF);

            return result;
        }

        // TODO MORAM DA VIDIM STA CU SA OVIMA
        public static string unsigned_to_unicode(uint input) {
            string result = "";

            char temp = (char)(input & 0xFF);
            if (temp != '\0') { result += temp; }

            temp = (char)((input >> 8) & 0xFF);
            if (temp != '\0') { result += temp; }

            temp = (char)((input >> 16) & 0xFF);
            if (temp != '\0') { result += temp; }

            temp = (char)((input >> 24) & 0xFF);
            if (temp != '\0') { result += temp; }

            return result;
        }
        public static string unsigned_array_to_unicode(uint[] input) {
            if (input == null) { throw new ArgumentNullException("invalid input"); }

            int input_lenght = input.Length;
            if (input_lenght == 0) { return ""; }

            string result = "";
            foreach(uint i in input) {
                result += unsigned_to_unicode(i);
            }
            return result;
        }

        public static uint unicode_to_uint(string input) {
            uint result = 0;
            result += ((uint)input[0]);
            result += ((uint)input[1] << 8);
            result += ((uint)input[2] << 16);
            result += ((uint)input[3] << 24);
            return result;
        }

        // todo vidi sta ces sa ovim
        public static uint[] unicode_to_uint_array(string input, int padding_size) {
            if (input == null) { throw new ArgumentNullException("invalid input"); }

            int input_lenght = input.Length;
            if (input_lenght == 0) { return new uint[0]; }

            byte[] unicode_bytes = get_bytes_from_unicode(input);
            return byte_array_to_unsigned_array(unicode_bytes, padding_size);


            //uint[] result = new uint[input_lenght / 4];
            //for (int i = 0 ; i < input_lenght; i += 4) {
            //    uint converted = unicode_to_uint(input.Substring(i, 4));
            //    result[i / 4] = converted;
            //}
            //return result;
        }


        // enigma
        public static string shift_string(string input, int value, bool right) {
            if (input == null) { return null; }

            if (value == 0) { return input; }
            value = Math.Abs(value);

            int input_lenght = input.Length;
            if (input_lenght < 2) { return input; }

            string output = input;

            for (int i = 0 ; i < value ; i++) {
                output = shift_string_internal(output, input_lenght, right);
            }

            return output;
        }
        private static string shift_string_internal(string input, int input_lenght, bool right) {
            int last_char_index = input_lenght - 1;
            
            string first_part = "";
            string second_part = "";

            if (right == true) {
                first_part = input[last_char_index].ToString();
                second_part = input.Substring(0, last_char_index);
            } else {
                first_part = input.Substring(1, last_char_index);
                second_part = input[0].ToString();
            }

            return first_part + second_part;
        }
    
        
        // random
        public static string random_unicode_key(uint lenght) {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] result = new byte[lenght];
            rng.GetNonZeroBytes(result);

            rng.Dispose();
            return get_unicode_from_bytes(result);
        }
        public static string rc4_random_key() {
            return random_unicode_key(48);
        }
        public static string tea_random_key() {
            return random_unicode_key(16);
        }


        // file i/o
        public static byte[] open_file_to_bytes(string filepath) {
            if (filepath == null) { throw new ArgumentNullException("invalid path"); }
            filepath = filepath.Trim();
            if (filepath.Length == 0) { throw new ArgumentException("invalid path"); }

            return File.ReadAllBytes(filepath);
        }
        public static void write_bytes_to_file(string filepath, byte[] bytes) {
            if (filepath == null) { throw new ArgumentNullException("invalid path"); }
            filepath = filepath.Trim();
            if (filepath.Length == 0) { throw new ArgumentException("invalid path"); }

            if (bytes == null) { throw new ArgumentNullException("invalid bytes"); }

            File.WriteAllBytes(filepath, bytes);
        }
    }
}
