using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CryptoProvider {
    [ServiceContract]
    public interface ICryptoProvider {

        // ###################################### RC4 ######################################
        [OperationContract] byte[] RC4_EncryptFile(string key, byte[] input);
        [OperationContract] byte[] RC4_DecryptFile(string key, byte[] input);

        [OperationContract] byte[] RC4_EncryptBitmap(string key, byte[] input);
        [OperationContract] byte[] RC4_DecryptBitmap(string key, byte[] input);

        [OperationContract] string[] RC4_EncryptText(string key, string[] input);
        [OperationContract] string[] RC4_DecryptText(string key, string[] input);

        [OperationContract] string RC4_EncryptPlaintext(string key, string input);
        [OperationContract] string RC4_DecryptPlaintext(string key, string input);

        // ###################################### TEA ######################################
        [OperationContract] byte[] TEA_EncryptFile(string key, byte[] input);
        [OperationContract] byte[] TEA_DecryptFile(string key, byte[] input);

        [OperationContract] byte[] TEA_EncryptBitmap(string key, byte[] input);
        [OperationContract] byte[] TEA_DecryptBitmap(string key, byte[] input);

        [OperationContract] string[] TEA_EncryptText(string key, string[] input);
        [OperationContract] string[] TEA_DecryptText(string key, string[] input);

        [OperationContract] string TEA_EncryptPlaintext(string key, string input);
        [OperationContract] string TEA_DecryptPlaintext(string key, string input);










        // ENIGMA
        //[OperationContract] string EnigmaCrypt(EnigmaState state, string input);

        //// TEA
        //[OperationContract] string TEACrypt(string key, string input);
        //[OperationContract] string TEADecrypt(string key, string input);
        //[OperationContract] byte[] TEABitmapCrypt(string key, byte[] input);
        //[OperationContract] byte[] TEABitmapDecrypt(string key, byte[] input);
        //[OperationContract] byte[] TEAFileCrypt(string key, byte[] input);
        //[OperationContract] byte[] TEAFileDecrypt(string key, byte[] input);

        //// CBC_TEA
        //[OperationContract] string CBC_TEACrypt(string key, string input, string init_vector);
        //[OperationContract] string CBC_TEADecrypt(string key, string input, string init_vector);
        //[OperationContract] byte[] CBC_TEABitmapCrypt(string key, byte[] input, string init_vector);
        //[OperationContract] byte[] CBC_TEABitmapDecrypt(string key, byte[] input, string init_vector);
        //[OperationContract] byte[] CBC_TEAFileCrypt(string key, byte[] input, string init_vector);
        //[OperationContract] byte[] CBC_TEAFileDecrypt(string key, byte[] input, string init_vector);

    }

    [DataContract]
    public class EnigmaState {
        int I_key;
        [DataMember]
        public int I_Key {
            get { return I_key; }
            set { I_key = value; }
        }

        int II_key;
        [DataMember]
        public int II_Key {
            get { return II_key; }
            set { II_key = value; }
        }

        int III_key;
        [DataMember]
        public int III_Key {
            get { return III_key; }
            set { III_key = value; }
        }

        char I_rotor_turnover_letter;
        [DataMember]
        public char I_Rotor_Turnover_Letter {
            get { return I_rotor_turnover_letter; }
            set { I_rotor_turnover_letter = value; }
        }

        char II_rotor_turnover_letter;
        [DataMember]
        public char II_Rotor_Turnover_Letter {
            get { return II_rotor_turnover_letter; }
            set { II_rotor_turnover_letter = value; }
        }

        char III_rotor_turnover_letter;
        [DataMember]
        public char III_Rotor_Turnover_Letter {
            get { return III_rotor_turnover_letter; }
            set { III_rotor_turnover_letter = value; }
        }

        string I_rotor_configuration;
        [DataMember]
        public string I_Rotor_Configuration {
            get { return I_rotor_configuration; }
            set { I_rotor_configuration = value; }
        }

        string II_rotor_configuration;
        [DataMember]
        public string II_Rotor_Configuration {
            get { return II_rotor_configuration; }
            set { II_rotor_configuration = value; }
        }

        string III_rotor_configuration;
        [DataMember]
        public string III_Rotor_Configuration {
            get { return III_rotor_configuration; }
            set { III_rotor_configuration = value; }
        }

        string reflector_configuration;
        [DataMember]
        public string Reflector_Configuration {
            get { return reflector_configuration; }
            set { reflector_configuration = value; }
        }

        string plug_board_configuration;
        [DataMember]
        public string Plug_Board_Configuration {
            get { return plug_board_configuration; }
            set { plug_board_configuration = value; }
        }
    }
}
