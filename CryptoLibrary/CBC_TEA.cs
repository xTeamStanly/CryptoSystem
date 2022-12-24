using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoLibrary;

namespace CryptoLibrary {
    public class CBC_TEA {
        private TEA tea = null;
        private uint[] init_vector = null;

        // CBC_TEA state
        // private uint[] input = null;
        // private uint[] output = null;
        private uint[] IV_key = null;

        private void setup(string tea_key, uint[] init_vector/*, bool should_pad_input*/) {
            tea = new TEA(tea_key/*, should_pad_input*/);
            this.init_vector = init_vector;

            IV_key = new uint[2];
        }

        public CBC_TEA(string tea_key, string init_vector_string/*, bool should_pad_input*/) {
            uint[] init_vector = Utility.unicode_to_uint_array(init_vector_string, 2); // todo check padding!!
            setup(tea_key, init_vector/*, should_pad_input*/);
        }

        public CBC_TEA(string tea_key, uint[] init_vector/*, bool should_pad_input*/) {
            setup(tea_key, init_vector/*, should_pad_input*/);
        }

        public void Encrypt(ref uint[] data) {
            if (data == null) { throw new Exception("invalid input"); }

            int data_lenght = data.Length;
            if (data_lenght == 0) { throw new Exception("invalid input"); }

            //if (data_lenght % 2 == 1) {
            //    if (tea.ShouldPadInput == true) {
            //        uint[] new_data = new uint[1] { 0 };
            //        data = new_data.Concat(data).ToArray();
            //    } else {
            //        throw new Exception("uncomplete block, padding is disabled");
            //    }
            //}

            // CBC_TEA state setup
            Array.Copy(init_vector, IV_key, 2);

            // CBC_TEA rounds
            for (int i = 0 ; i < data.Length ; i += 2) {
                uint[] input = new uint[2];
                input[0] = data[i] ^ IV_key[0];
                input[1] = data[i + 1] ^ IV_key[1];

                tea.encrypt_one_cycle(input);

                data[i] = input[0];
                data[i + 1] = input[1];

                Array.Copy(input, IV_key, 2);
            }
        }

        public void Decrypt(uint[] data) {
            if (data == null) { throw new Exception("invalid input"); }

            int data_lenght = data.Length;
            if (data_lenght == 0) { throw new Exception("invalid input"); }

            // if (data_lenght % 2 == 1) { throw new Exception("uncomplete block"); }

            // CBC_TEA state setup
            Array.Copy(init_vector, IV_key, 2);

            // CBC_TEA rounds
            for (int i = 0 ; i < data.Length ; i += 2) {
                uint[] input = new uint[2];
                input[0] = data[i];
                input[1] = data[i + 1];

                uint[] input_copy = new uint[2];
                Array.Copy(input, input_copy, 2);

                tea.decrypt_one_cycle(input);

                data[i] = input[0] ^ IV_key[0];
                data[i + 1] = input[1] ^ IV_key[1];
                
                Array.Copy(input_copy, IV_key, 2);
            }
        }
    
        public byte[] encrypt_bytes_to_bytes(byte[] input) {
            uint[] data = Utility.byte_array_to_unsigned_array(input, 2);
            Encrypt(ref data);
            return Utility.unsigned_array_to_byte_array(data);
        }
        public string encrypt_bytes_to_unicode(byte[] input) {
            uint[] data = Utility.byte_array_to_unsigned_array(input, 2);
            Encrypt(ref data);
            return Utility.unsigned_array_to_unicode(data);
        }
        public string encrypt_unicode_to_unicode(string input) {
            byte[] input_bytes = Utility.get_bytes_from_unicode(input);
            return encrypt_bytes_to_unicode(input_bytes);
        }
        public byte[] encrypt_unicode_to_bytes(string input) {
            byte[] input_bytes = Utility.get_bytes_from_unicode(input);
            return encrypt_bytes_to_bytes(input_bytes);
        }

        public byte[] decrypt_bytes_to_bytes(byte[] input) {
            uint[] data = Utility.byte_array_to_unsigned_array(input, 2);
            Decrypt(data);
            return Utility.unsigned_array_to_byte_array(data);
        }
        public string decrypt_bytes_to_unicode(byte[] input) {
            uint[] data = Utility.byte_array_to_unsigned_array(input, 2);
            Decrypt(data);
            return Utility.unsigned_array_to_unicode(data);
        }
        public string decrypt_unicode_to_unicode(string input) {
            uint[] data = Utility.unicode_to_uint_array(input, 2);
            Decrypt(data);
            return Utility.unsigned_array_to_unicode(data);
        }
        public byte[] decrypt_unicode_to_bytes(string input) {
            uint[] data = Utility.unicode_to_uint_array(input, 2);
            Decrypt(data);
            return Utility.unsigned_array_to_byte_array(data);
        }

    }
}
