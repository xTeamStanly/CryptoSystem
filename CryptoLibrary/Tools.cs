using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library {
    public static class Tools {

        public static byte[] RandomBytes(uint lenght) {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] result = new byte[lenght];
            rng.GetNonZeroBytes(result);
            rng.Dispose();
            return result;
        }

        public static string RandomString(uint lenght) {
            byte[] bytes = RandomBytes(lenght);
            return Convertor.bytes_to_string(bytes);
        }

        public static string RandomBinaryString(uint lenght) {
            string result = "";

            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            byte[] bytes = new byte[lenght];
            rng.GetBytes(bytes);

            for (int i = 0 ; i < lenght - 1 ; i++) {
                result += ((bytes[i] % 2) == 0 ? '0' : '1');
            }

            // makar jedna jedinica
            if (result.Contains('1') == true) {
                result += ((bytes[lenght - 1] % 2) == 0 ? '0' : '1');
            } else {
                result += '1';
            }

            return result;
        }

        public static string GetLast(string input, int lenght) {
            if (input == null) { throw new ArgumentNullException("Input string is null"); }

            int input_lenght = input.Length;
            lenght = Math.Abs(lenght);

            if (lenght >= input_lenght) { return input; }

            return input.Substring(input_lenght - lenght);
        }
    }
}
