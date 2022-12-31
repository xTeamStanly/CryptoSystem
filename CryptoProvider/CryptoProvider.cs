using Library.Crypto;
using Library.Crypto.Enigma;
using System;
using System.ServiceModel;

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

        // ###################################### ENIGMA ######################################
        public string Enigma_Encode(EnigmaState enigma_state, string message) {
            try {
                if (enigma_state == null) { throw new ArgumentNullException("Enigma state is null"); }

                Rotor slowrotor = new Rotor(Rotors.rotors[(int)enigma_state.SlowType]);
                slowrotor.rotation = enigma_state.SlowRotation;
                slowrotor.start_position = enigma_state.SlowStart;

                Rotor middlerotor = new Rotor(Rotors.rotors[(int)enigma_state.MiddleType]);
                middlerotor.rotation = enigma_state.MiddleRotation;
                middlerotor.start_position = enigma_state.MiddleStart;

                Rotor fastrotor = new Rotor(Rotors.rotors[(int)enigma_state.FastType]);
                fastrotor.rotation = enigma_state.FastRotation;
                fastrotor.start_position = enigma_state.FastStart;

                Reflector reflector = new Reflector(Reflectors.reflectors[(int)enigma_state.ReflectorType]);

                Enigma cipher = new Enigma(reflector, new Rotor[] { fastrotor, middlerotor, slowrotor }, enigma_state.PlugboardConfiguration);
                return cipher.Get(message);
            } catch (Exception ex) {
                return ex.Message;
            }
        }        
    }
}
