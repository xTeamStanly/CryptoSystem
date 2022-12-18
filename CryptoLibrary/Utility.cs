using System;
using System.Text;

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


    
    }
}
