using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CryptoLibrary;
using CryptoLibrary.Enigma;
namespace CryptoProvider {

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CryptoProvider : ICryptoProvider {

        // RC4
        public string RC4Crypt(string key, string input) {
            try {
                RC4 rc4 = new RC4(key);
                return rc4.encrypt_unicode_to_unicode(input);
            } catch (Exception ex) {
                return ex.Message;
            }
        }
        public string RC4Decrypt(string key, string input) {
            try {
                RC4 rc4 = new RC4(key);
                return rc4.decrypt_unicode_to_unicode(input);
            } catch (Exception ex) {
                return ex.Message;
            }
        }
        public byte[] RC4BitmapCrypt(string key, byte[] input) {
            try {
                RC4 rc4 = new RC4(key);
                return rc4.encrypt_bitmap_from_bytes(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] RC4BitmapDecrypt(string key, byte[] input) {
            try {
                RC4 rc4 = new RC4(key);
                return rc4.decrypt_bitmap_from_bytes(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // ENIGMA
        public string EnigmaCrypt(EnigmaState state, string input) {
            try {

                Enigma enigma = new Enigma(
                    state.I_Key, state.I_Rotor_Configuration, state.I_Rotor_Turnover_Letter,
                    state.II_Key, state.II_Rotor_Configuration, state.II_Rotor_Turnover_Letter,
                    state.III_Key, state.III_Rotor_Configuration, state.III_Rotor_Turnover_Letter,
                    state.Reflector_Configuration, state.Plug_Board_Configuration
                );

                return enigma.Get(input);

            } catch (Exception ex) {
                return ex.Message;
            }
        }

        // TEA
        public string TEACrypt(string key, string input) {
            try {
                if (key.Length != 16) { throw new Exception("invalid key"); }

                TEA tea = new TEA(key);
                return tea.encrypt_unicode_to_unicode(input);
            } catch (Exception ex) {
                return ex.Message;
            }
        }
        public string TEADecrypt(string key, string input) {
            try {
                if (key.Length != 16) { throw new Exception("invalid key"); }

                TEA tea = new TEA(key);
                return tea.decrypt_unicode_to_unicode(input);
            } catch (Exception ex) {
                return ex.Message;
            }
        }
        public byte[] TEABitmapCrypt(string key, byte[] input) {
            try {
                if (key.Length != 16) { throw new Exception("invalid key"); }

                TEA tea = new TEA(key);
                return tea.encrypt_bitmap_from_bytes(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] TEABitmapDecrypt(string key, byte[] input) {
            try {
                if (key.Length != 16) { throw new Exception("invalid key"); }

                TEA tea = new TEA(key);
                return tea.decrypt_bitmap_from_bytes(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // CBC_TEA
        public string CBC_TEACrypt(string key, string input, string init_vector/*, bool should_pad_input*/) {
            try {
                if (key.Length != 16) { throw new Exception("invalid key"); }

                CBC_TEA cbc_tea = new CBC_TEA(key, init_vector/*, should_pad_input*/);
                return cbc_tea.encrypt_unicode_to_unicode(input);
            } catch (Exception ex) {
                return ex.Message;
            }
        }
        public string CBC_TEADecrypt(string key, string input, string init_vector/*, bool should_pad_input*/) {
            try {
                // if (input.Length % 8 != 0) { throw new Exception("uncomplete block"); }
                if (key.Length != 16) { throw new Exception("invalid key"); }

                CBC_TEA cbc_tea = new CBC_TEA(key, init_vector/*, should_pad_input*/);
                return cbc_tea.decrypt_unicode_to_unicode(input);
            } catch (Exception ex) {
                return ex.Message;
            }
        }
    }
}
