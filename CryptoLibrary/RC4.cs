using System.Linq;
using System.Text;

namespace CryptoLibrary.RC4 {
    public class RC4 {

        // key bytes
        private byte[] key_bytes = null;
        private uint key_bytes_lenght = 0;
        public byte[] KeyBytes { get { return key_bytes; } }

        // unicode key
        private string key_unicode = null;
        public string KeyUnicode { get { return key_unicode; } }

        // sbox
        private byte[] s = null;

        public byte[] Encrypt(byte[] input) {

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

        public RC4(string unicode_key) {
            Utility.valid_unicode(unicode_key);

            key_bytes = Encoding.UTF8.GetBytes(unicode_key);
            key_bytes_lenght = (uint)key_bytes.Length;
            key_unicode = unicode_key;

            s = new byte[256];
        }

        public RC4(byte[] bytes_key) {
            Utility.valid_bytes(bytes_key);

            key_unicode = Encoding.UTF8.GetString(bytes_key);
            key_bytes = bytes_key;
            key_bytes_lenght = (uint)key_bytes.Length;

            s = new byte[256];
        }

        public byte[] encrypt_bytes_to_bytes(byte[] input) { return Encrypt(input); }
        public string encrypt_bytes_to_unicode(byte[] input) { return Utility.get_unicode_from_bytes(Encrypt(input)); }
        public string encrypt_unicode_to_unicode(string input) {
            byte[] input_bytes = Utility.get_bytes_from_unicode(input);
            return encrypt_bytes_to_unicode(input_bytes);
        }
        public byte[] encrypt_unicode_to_bytes(string input) {
            byte[] input_bytes = Utility.get_bytes_from_unicode(input);
            return Encrypt(input_bytes);
        }

        public byte[] decrypt_bytes_to_bytes(byte[] input) { return encrypt_bytes_to_bytes(input); }
        public string decrypt_bytes_to_unicode(byte[] input) { return encrypt_bytes_to_unicode(input); }
        public string decrypt_unicode_to_unicode(string input) { return encrypt_unicode_to_unicode(input); }
        public byte[] decrypt_unicode_to_bytes(string input) { return encrypt_unicode_to_bytes(input); }


    }
}
