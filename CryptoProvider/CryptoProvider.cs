using Library.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
// using CryptoLibrary.Enigma;

namespace CryptoProvider {

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CryptoProvider : ICryptoProvider {

        // ###################################### RC4 ######################################
        public byte[] RC4_EncryptFile(string key, byte[] input) {
            try {
                RC4 cipher = new RC4(key);
                return cipher.EncryptFile(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] RC4_DecryptFile(string key, byte[] input) {
            try {
                RC4 cipher = new RC4(key);
                return cipher.DecryptFile(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] RC4_EncryptBitmap(string key, byte[] input) {
            try {
                RC4 cipher = new RC4(key);
                return cipher.EncryptBitmap(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] RC4_DecryptBitmap(string key, byte[] input) {
            try {
                RC4 cipher = new RC4(key);
                return cipher.DecryptBitmap(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string[] RC4_EncryptText(string key, string[] input) {
            try {
                RC4 cipher = new RC4(key);
                return cipher.EncryptText(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string[] RC4_DecryptText(string key, string[] input) {
            try {
                RC4 cipher = new RC4(key);
                return cipher.DecryptText(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string RC4_EncryptPlaintext(string key, string input) {
            try {
                RC4 cipher = new RC4(key);
                return cipher.EncryptPlaintext(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string RC4_DecryptPlaintext(string key, string input) {
            try {
                RC4 cipher = new RC4(key);
                return cipher.DecryptPlaintext(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // ###################################### TEA ######################################
        public byte[] TEA_EncryptFile(string key, byte[] input) {
            try {
                TEA cipher = new TEA(key);
                return cipher.EncryptFile(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] TEA_DecryptFile(string key, byte[] input) {
            try {
                TEA cipher = new TEA(key);
                return cipher.DecryptFile(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] TEA_EncryptBitmap(string key, byte[] input) {
            try {
                TEA cipher = new TEA(key);
                return cipher.EncryptBitmap(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] TEA_DecryptBitmap(string key, byte[] input) {
            try {
                TEA cipher = new TEA(key);
                return cipher.DecryptBitmap(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string[] TEA_EncryptText(string key, string[] input) {
            try {
                TEA cipher = new TEA(key);
                return cipher.EncryptText(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string[] TEA_DecryptText(string key, string[] input) {
            try {
                TEA cipher = new TEA(key);
                return cipher.DecryptText(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string TEA_EncryptPlaintext(string key, string input) {
            try {
                TEA cipher = new TEA(key);
                return cipher.EncryptPlaintext(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string TEA_DecryptPlaintext(string key, string input) {
            try {
                TEA cipher = new TEA(key);
                return cipher.DecryptPlaintext(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // ###################################### CBC-TEA ######################################
        public byte[] CBC_EncryptFile(string key, byte[] input, string initialization_vector) {
            try {
                CBCTEA cipher = new CBCTEA(key, initialization_vector);
                return cipher.EncryptFile(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] CBC_DecryptFile(string key, byte[] input, string initialization_vector) {
            try {
                CBCTEA cipher = new CBCTEA(key, initialization_vector);
                return cipher.DecryptFile(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] CBC_EncryptBitmap(string key, byte[] input, string initialization_vector) {
            try {
                CBCTEA cipher = new CBCTEA(key, initialization_vector);
                return cipher.EncryptBitmap(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] CBC_DecryptBitmap(string key, byte[] input, string initialization_vector) {
            try {
                CBCTEA cipher = new CBCTEA(key, initialization_vector);
                return cipher.DecryptBitmap(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string[] CBC_EncryptText(string key, string[] input, string initialization_vector) {
            try {
                CBCTEA cipher = new CBCTEA(key, initialization_vector);
                return cipher.EncryptText(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string[] CBC_DecryptText(string key, string[] input, string initialization_vector) {
            try {
                CBCTEA cipher = new CBCTEA(key, initialization_vector);
                return cipher.DecryptText(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string CBC_EncryptPlaintext(string key, string input, string initialization_vector) {
            try {
                CBCTEA cipher = new CBCTEA(key, initialization_vector);
                return cipher.EncryptPlaintext(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string CBC_DecryptPlaintext(string key, string input, string initialization_vector) {
            try {
                CBCTEA cipher = new CBCTEA(key, initialization_vector);
                return cipher.DecryptPlaintext(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // ###################################### CRC ######################################
        public ulong? CRC_ChecksumFile(string key, byte[] input) {
            try {
                CRC cipher = new CRC(key);
                return cipher.ChecksumFile(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public ulong? CRC_ChecksumTextFile(string key, string[] input) {
            try {
                CRC cipher = new CRC(key);
                return cipher.ChecksumTextFile(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public ulong? CRC_ChecksumPlaintext(string key, string input) {
            try {
                CRC cipher = new CRC(key);
                return cipher.ChecksumPlaintext(input);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // ENIGMA
        //public string EnigmaCrypt(EnigmaState state, string input) {
        //    try {

        //        Enigma enigma = new Enigma(
        //            state.I_Key, state.I_Rotor_Configuration, state.I_Rotor_Turnover_Letter,
        //            state.II_Key, state.II_Rotor_Configuration, state.II_Rotor_Turnover_Letter,
        //            state.III_Key, state.III_Rotor_Configuration, state.III_Rotor_Turnover_Letter,
        //            state.Reflector_Configuration, state.Plug_Board_Configuration
        //        );

        //        return enigma.Get(input);

        //    } catch (Exception ex) {
        //        return ex.Message;
        //    }
        //}



        //// CBC_TEA
        //public string CBC_TEACrypt(string key, string input, string init_vector) {
        //    try {
        //        if (key.Length != 16) { throw new Exception("invalid key"); }

        //        CBC_TEA cbc_tea = new CBC_TEA(key, init_vector);
        //        return cbc_tea.encrypt_unicode_to_unicode(input);
        //    } catch (Exception ex) {
        //        return ex.Message;
        //    }
        //}
        //public string CBC_TEADecrypt(string key, string input, string init_vector) {
        //    try {
        //        // if (input.Length % 8 != 0) { throw new Exception("uncomplete block"); }
        //        if (key.Length != 16) { throw new Exception("invalid key"); }

        //        CBC_TEA cbc_tea = new CBC_TEA(key, init_vector);
        //        return cbc_tea.decrypt_unicode_to_unicode(input);
        //    } catch (Exception ex) {
        //        return ex.Message;
        //    }
        //}
        //public byte[] CBC_TEABitmapCrypt(string key, byte[] input, string init_vector) {
        //    try {
        //        if (key.Length != 16) { throw new Exception("invalid key"); }

        //        CBC_TEA cbc_tea = new CBC_TEA(key, init_vector);
        //        return cbc_tea.encrypt_bitmap_from_bytes(input);
        //    } catch (Exception ex) {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}
        //public byte[] CBC_TEABitmapDecrypt(string key, byte[] input, string init_vector) {
        //    try {
        //        if (key.Length != 16) { throw new Exception("invalid key"); }

        //        CBC_TEA cbc_tea = new CBC_TEA(key, init_vector);
        //        return cbc_tea.decrypt_bitmap_from_bytes(input);
        //    } catch (Exception ex) {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}
        //public byte[] CBC_TEAFileCrypt(string key, byte[] input, string init_vector) {
        //    try {
        //        if (key.Length != 16) { throw new Exception("invalid key"); }

        //        CBC_TEA cbc_tea = new CBC_TEA(key, init_vector);
        //        return cbc_tea.encrypt_bytes_to_bytes(input);
        //    } catch (Exception ex) {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}
        //public byte[] CBC_TEAFileDecrypt(string key, byte[] input, string init_vector) {
        //    try {
        //        if (key.Length != 16) { throw new Exception("invalid key"); }

        //        CBC_TEA cbc_tea = new CBC_TEA(key, init_vector);
        //        return cbc_tea.decrypt_bytes_to_bytes(input);
        //    } catch (Exception ex) {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}


    }
}
