using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CryptoLibrary {
    public static class Utility {

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

        public static byte[] get_bytes_from_unicode(string unicode_input) {
            if (unicode_input == null) { throw new ArgumentNullException("Invalid input"); }
             
            int unicode_input_lenght = unicode_input.Length;
            if (unicode_input_lenght < 1) { throw new ArgumentException("Invalid input"); }

            byte[] bytes = Encoding.UTF8.GetBytes(unicode_input);
            return bytes;
        }
        public static string get_unicode_from_bytes(byte[] bytes_input) {
            if (bytes_input == null) { throw new ArgumentNullException("Invalid input"); }

            int bytes_input_lenght = bytes_input.Length;
            if (bytes_input_lenght < 1) { throw new ArgumentException("Invalid input"); }

            string unicode = Encoding.UTF8.GetString(bytes_input);
            return unicode;
        }

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
        public static int alphabet_letter_to_number(char letter) {
            bool small_letter = letter >= 'a' && letter <= 'z';
            bool big_letter = letter >= 'A' && letter <= 'Z';
            
            if (small_letter == false && big_letter == false) { return -1; }
            
            byte letter_byte = Encoding.UTF8.GetBytes(letter.ToString()).First();
            return letter_byte & 0b11111; // bitmask ascii/utf8 hack
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
            for (int i = 0 ; i < configuration_string_lenght ; i += 2) {
                char first = configuration_string[i];
                char second = configuration_string[i + 1];

                if (first == second) { continue; }
                if (dictionary.ContainsKey(first) == true || dictionary.ContainsKey(second) == true) { continue; }

                dictionary.Add(first, second);
                dictionary.Add(second, first);
            }

            return dictionary;
        }
    
    }
}
