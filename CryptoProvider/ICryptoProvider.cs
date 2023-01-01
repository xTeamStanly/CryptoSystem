using Library.Crypto.Enigma;
using System.Runtime.Serialization;
using System.ServiceModel;
using static Library.Crypto.Enigma.Reflectors;
using static Library.Crypto.Enigma.Rotors;

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

        // ###################################### ENIGMA ######################################
        [OperationContract] string Enigma_Encode(EnigmaState enigma_state, string message);

        // ###################################### TEA ######################################
        [OperationContract] byte[] TEA_EncryptFile(string key, byte[] input);
        [OperationContract] byte[] TEA_DecryptFile(string key, byte[] input);

        [OperationContract] byte[] TEA_EncryptBitmap(string key, byte[] input);
        [OperationContract] byte[] TEA_DecryptBitmap(string key, byte[] input);

        [OperationContract] string[] TEA_EncryptText(string key, string[] input);
        [OperationContract] string[] TEA_DecryptText(string key, string[] input);

        [OperationContract] string TEA_EncryptPlaintext(string key, string input);
        [OperationContract] string TEA_DecryptPlaintext(string key, string input);

        // ###################################### CBC-TEA ######################################
        [OperationContract] byte[] CBC_EncryptFile(string key, byte[] input, string initialization_vector);
        [OperationContract] byte[] CBC_DecryptFile(string key, byte[] input, string initialization_vector);

        [OperationContract] byte[] CBC_EncryptBitmap(string key, byte[] input, string initialization_vector);
        [OperationContract] byte[] CBC_DecryptBitmap(string key, byte[] input, string initialization_vector);

        [OperationContract] string[] CBC_EncryptText(string key, string[] input, string initialization_vector);
        [OperationContract] string[] CBC_DecryptText(string key, string[] input, string initialization_vector);

        [OperationContract] string CBC_EncryptPlaintext(string key, string input, string initialization_vector);
        [OperationContract] string CBC_DecryptPlaintext(string key, string input, string initialization_vector);

        // ###################################### CRC ######################################
        [OperationContract] ulong? CRC_ChecksumFile(string key, byte[] input, int thread_count);
        [OperationContract] ulong? CRC_ChecksumTextFile(string key, string[] input);
        [OperationContract] ulong? CRC_ChecksumPlaintext(string key, string input);
    }

    [DataContract]
    public class EnigmaState {
        [DataMember] public RotorType SlowType { get; set; }
        [DataMember] public int SlowRotation { get; set; }
        [DataMember] public int SlowStart { get; set; }

        [DataMember] public RotorType MiddleType { get; set; }
        [DataMember] public int MiddleRotation { get; set; }
        [DataMember] public int MiddleStart { get; set; }

        [DataMember] public RotorType FastType { get; set; }
        [DataMember] public int FastRotation { get; set; }
        [DataMember] public int FastStart { get; set; }
        
        [DataMember] public ReflectorType ReflectorType { get; set; }

        [DataMember] public string PlugboardConfiguration { get; set; }
    }
}
