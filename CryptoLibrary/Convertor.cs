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


    }
}
