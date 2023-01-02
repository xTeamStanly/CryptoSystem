using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Crypto {
    public class RC4 {

        private static void valid_unicode(string input) {
            if (input == null) { throw new ArgumentException("Input string is null"); }

            int input_lenght = input.Length;
            if (input_lenght < 1) { throw new ArgumentException("Input string is empty"); }
        }
        private static void valid_bytes(byte[] input) {
            if (input == null) { throw new ArgumentException("Input byte array is null"); }

            int input_lenght = input.Length;
            if (input_lenght < 1) { throw new ArgumentException("Input byte array is empty"); }
        }

        // bytes key
        private byte[] key_bytes = null;
        private uint key_bytes_lenght = 0;
        public byte[] KeyBytes { get { return key_bytes; } }

        // unicode key
        private string key_unicode = null;
        public string KeyUnicode { get { return key_unicode; } }

        // sbox
        private byte[] s = null;

        public RC4(string unicode_key) {
            valid_unicode(unicode_key);

            key_bytes = Convertor.string_to_bytes(unicode_key);
            key_bytes_lenght = (uint)key_bytes.Length;
            key_unicode = unicode_key;

            s = new byte[256];
        }

        public RC4(byte[] bytes_key) {
            valid_bytes(bytes_key);

            key_unicode = Convertor.bytes_to_string(bytes_key);
            key_bytes = bytes_key;
            key_bytes_lenght = (uint)key_bytes.Length;

            s = new byte[256];
        }

        public byte[] Encrypt(byte[] input) {
            if (input == null) { throw new ArgumentNullException("Input byte array is null"); }

            uint i, j, n;

            // key schedule algorithm
            for (i = 0 ; i < 256 ; i++) {
                s[i] = (byte)i;
            }

            j = 0;
            for (i = 0 ; i < 256 ; i++) {
                j = (j + s[i] + key_bytes[i % key_bytes_lenght]) & 0xFF;
                byte temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }

            // pseudo random generation algorithm
            byte[] output = Enumerable.Repeat<byte>(0, input.Length).ToArray();
            i = 0;
            j = 0;
            for (n = 0 ; n < input.Length ; n++) {
                i = (i + 1) & 0xFF;
                j = (j + s[i]) & 0xFF;

                byte temp = s[i];
                s[i] = s[j];
                s[j] = temp;

                byte generated = s[ (s[i] + s[j]) & 0xFF ];
                output[n] = (byte)(generated ^ input[n]);
            }

            return output;
        }
        public byte[] Decrypt(byte[] input) {
            return Encrypt(input);
        }

        public byte[] EncryptFile(byte[] input) {
            return Encrypt(input);
        }
        public byte[] DecryptFile(byte[] input) {
            return Decrypt(input);
        }
        public void EncryptFile(string inputpath, string outputpath) {
            byte[] input_bytes = IO.OpenFile(inputpath);
            if (input_bytes.Length == 0) { throw new Exception("No data"); }
            
            byte[] output_bytes = Encrypt(input_bytes);
            IO.SaveFile(outputpath, output_bytes);
        }
        public void DecryptFile(string inputpath, string outputpath) {
            byte[] input_bytes = IO.OpenFile(inputpath);
            if (input_bytes.Length == 0) { throw new Exception("No data"); }
            
            byte[] output_bytes = Decrypt(input_bytes);
            IO.SaveFile(outputpath, output_bytes);
        }
        
        public byte[] EncryptBitmap(byte[] input) {
            if (input == null) { throw new Exception("Input byte array is null"); }
            
            int input_lenght = input.Length;
            if (input.Length == 0) { throw new Exception("Input byte array is empty"); }

            int end_of_header_position = input[10] + 256 * (input[11] + 256 * (input[12] + 256 * input[13]));

            // samo informacije o pikselima
            byte[] input_pixels = new byte[input_lenght - end_of_header_position];
            // preskocili smo header i kopiramo samo informacije o pikselima
            Array.Copy(input, end_of_header_position, input_pixels, 0, input_pixels.Length);

            input_pixels = Encrypt(input_pixels);

            // moze da se desi da je slika previse mala pa mora da se padduje, primer 1x1 slika
            // u takvom slucaju slika nece biti iste velicine kao originalna, nego za 4 bajta veca
            // ti bajtovi su 0x00 (padding)

            byte[] output = new byte[end_of_header_position + input_pixels.Length];
            Array.Copy(input, 0, output, 0, end_of_header_position); // kopiramo header
            Array.Copy(input_pixels, 0, output, end_of_header_position, input_pixels.Length); // kopiramo data bez hedera

            return output;
        }
        public byte[] DecryptBitmap(byte[] input) {
            if (input == null) { throw new Exception("Input byte array is null"); }

            int input_lenght = input.Length;
            if (input.Length == 0) { throw new Exception("Input byte array is empty"); }

            int end_of_header_position = input[10] + 256 * (input[11] + 256 * (input[12] + 256 * input[13]));

            byte[] input_pixels = new byte[input_lenght - end_of_header_position];
            Array.Copy(input, end_of_header_position, input_pixels, 0, input_pixels.Length);

            input_pixels = Decrypt(input_pixels);

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
            // if (input.Length == 0) { throw new Exception("No data"); }

            return input.Select(i => EncryptPlaintext(i)).ToArray();
        }
        public string[] DecryptText(string[] input) {
            if (input == null) { throw new Exception("Input string array is null"); }
            // if (input.Length == 0) { throw new Exception("No data"); }

            return input.Select(i => DecryptPlaintext(i)).ToArray();
        }
        public void EncryptText(string inputpath, string outputpath) {
            string[] input_strings = IO.OpenTextFile(inputpath);
            // if (input_strings.Length == 0) { throw new Exception("No data"); }

            string[] output_strings = EncryptText(input_strings);
            IO.SaveTextFile(outputpath, output_strings);
        }
        public void DecryptText(string inputpath, string outputpath) {
            string[] input_strings = IO.OpenTextFile(inputpath);
            // if (input_strings.Length == 0) { throw new Exception("No data"); }

            string[] output_strings = DecryptText(input_strings);
            IO.SaveTextFile(outputpath, output_strings);
        }

        public string EncryptPlaintext(string input) {
            if (input == null) { throw new Exception("Input string is null"); }
            byte[] bytes = Convertor.string_to_bytes(input);
            // if (bytes.Length == 0) { throw new Exception("No data"); }

            bytes = Encrypt(bytes);
            return Convertor.bytes_to_string(bytes);
        }
        public string DecryptPlaintext(string input) {
            if (input == null) { throw new Exception("Input string is null"); }
            byte[] bytes = Convertor.string_to_bytes(input);
            // if (bytes.Length == 0) { throw new Exception("No data"); }

            bytes = Decrypt(bytes);
            return Convertor.bytes_to_string(bytes);
        }

    }
}
