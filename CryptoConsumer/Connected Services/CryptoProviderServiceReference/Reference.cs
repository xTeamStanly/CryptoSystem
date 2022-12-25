﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CryptoConsumer.CryptoProviderServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CryptoProviderServiceReference.ICryptoProvider")]
    public interface ICryptoProvider {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4Crypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4CryptResponse")]
        string RC4Crypt(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4Crypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4CryptResponse")]
        System.Threading.Tasks.Task<string> RC4CryptAsync(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4Decrypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4DecryptResponse")]
        string RC4Decrypt(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4Decrypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4DecryptResponse")]
        System.Threading.Tasks.Task<string> RC4DecryptAsync(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4BitmapCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4BitmapCryptResponse")]
        byte[] RC4BitmapCrypt(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4BitmapCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4BitmapCryptResponse")]
        System.Threading.Tasks.Task<byte[]> RC4BitmapCryptAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4BitmapDecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4BitmapDecryptResponse")]
        byte[] RC4BitmapDecrypt(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4BitmapDecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4BitmapDecryptResponse")]
        System.Threading.Tasks.Task<byte[]> RC4BitmapDecryptAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4FileCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4FileCryptResponse")]
        byte[] RC4FileCrypt(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4FileCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4FileCryptResponse")]
        System.Threading.Tasks.Task<byte[]> RC4FileCryptAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4FileDecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4FileDecryptResponse")]
        byte[] RC4FileDecrypt(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4FileDecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/RC4FileDecryptResponse")]
        System.Threading.Tasks.Task<byte[]> RC4FileDecryptAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/EnigmaCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/EnigmaCryptResponse")]
        string EnigmaCrypt(CryptoProvider.EnigmaState state, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/EnigmaCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/EnigmaCryptResponse")]
        System.Threading.Tasks.Task<string> EnigmaCryptAsync(CryptoProvider.EnigmaState state, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEACrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEACryptResponse")]
        string TEACrypt(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEACrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEACryptResponse")]
        System.Threading.Tasks.Task<string> TEACryptAsync(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEADecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEADecryptResponse")]
        string TEADecrypt(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEADecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEADecryptResponse")]
        System.Threading.Tasks.Task<string> TEADecryptAsync(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEABitmapCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEABitmapCryptResponse")]
        byte[] TEABitmapCrypt(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEABitmapCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEABitmapCryptResponse")]
        System.Threading.Tasks.Task<byte[]> TEABitmapCryptAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEABitmapDecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEABitmapDecryptResponse")]
        byte[] TEABitmapDecrypt(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEABitmapDecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEABitmapDecryptResponse")]
        System.Threading.Tasks.Task<byte[]> TEABitmapDecryptAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEAFileCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEAFileCryptResponse")]
        byte[] TEAFileCrypt(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEAFileCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEAFileCryptResponse")]
        System.Threading.Tasks.Task<byte[]> TEAFileCryptAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEAFileDecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEAFileDecryptResponse")]
        byte[] TEAFileDecrypt(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEAFileDecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/TEAFileDecryptResponse")]
        System.Threading.Tasks.Task<byte[]> TEAFileDecryptAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_TEACrypt", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_TEACryptResponse")]
        string CBC_TEACrypt(string key, string input, string init_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_TEACrypt", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_TEACryptResponse")]
        System.Threading.Tasks.Task<string> CBC_TEACryptAsync(string key, string input, string init_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_TEADecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_TEADecryptResponse")]
        string CBC_TEADecrypt(string key, string input, string init_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_TEADecrypt", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_TEADecryptResponse")]
        System.Threading.Tasks.Task<string> CBC_TEADecryptAsync(string key, string input, string init_vector);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICryptoProviderChannel : CryptoConsumer.CryptoProviderServiceReference.ICryptoProvider, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CryptoProviderClient : System.ServiceModel.ClientBase<CryptoConsumer.CryptoProviderServiceReference.ICryptoProvider>, CryptoConsumer.CryptoProviderServiceReference.ICryptoProvider {
        
        public CryptoProviderClient() {
        }
        
        public CryptoProviderClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CryptoProviderClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CryptoProviderClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CryptoProviderClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string RC4Crypt(string key, string input) {
            return base.Channel.RC4Crypt(key, input);
        }
        
        public System.Threading.Tasks.Task<string> RC4CryptAsync(string key, string input) {
            return base.Channel.RC4CryptAsync(key, input);
        }
        
        public string RC4Decrypt(string key, string input) {
            return base.Channel.RC4Decrypt(key, input);
        }
        
        public System.Threading.Tasks.Task<string> RC4DecryptAsync(string key, string input) {
            return base.Channel.RC4DecryptAsync(key, input);
        }
        
        public byte[] RC4BitmapCrypt(string key, byte[] input) {
            return base.Channel.RC4BitmapCrypt(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> RC4BitmapCryptAsync(string key, byte[] input) {
            return base.Channel.RC4BitmapCryptAsync(key, input);
        }
        
        public byte[] RC4BitmapDecrypt(string key, byte[] input) {
            return base.Channel.RC4BitmapDecrypt(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> RC4BitmapDecryptAsync(string key, byte[] input) {
            return base.Channel.RC4BitmapDecryptAsync(key, input);
        }
        
        public byte[] RC4FileCrypt(string key, byte[] input) {
            return base.Channel.RC4FileCrypt(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> RC4FileCryptAsync(string key, byte[] input) {
            return base.Channel.RC4FileCryptAsync(key, input);
        }
        
        public byte[] RC4FileDecrypt(string key, byte[] input) {
            return base.Channel.RC4FileDecrypt(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> RC4FileDecryptAsync(string key, byte[] input) {
            return base.Channel.RC4FileDecryptAsync(key, input);
        }
        
        public string EnigmaCrypt(CryptoProvider.EnigmaState state, string input) {
            return base.Channel.EnigmaCrypt(state, input);
        }
        
        public System.Threading.Tasks.Task<string> EnigmaCryptAsync(CryptoProvider.EnigmaState state, string input) {
            return base.Channel.EnigmaCryptAsync(state, input);
        }
        
        public string TEACrypt(string key, string input) {
            return base.Channel.TEACrypt(key, input);
        }
        
        public System.Threading.Tasks.Task<string> TEACryptAsync(string key, string input) {
            return base.Channel.TEACryptAsync(key, input);
        }
        
        public string TEADecrypt(string key, string input) {
            return base.Channel.TEADecrypt(key, input);
        }
        
        public System.Threading.Tasks.Task<string> TEADecryptAsync(string key, string input) {
            return base.Channel.TEADecryptAsync(key, input);
        }
        
        public byte[] TEABitmapCrypt(string key, byte[] input) {
            return base.Channel.TEABitmapCrypt(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> TEABitmapCryptAsync(string key, byte[] input) {
            return base.Channel.TEABitmapCryptAsync(key, input);
        }
        
        public byte[] TEABitmapDecrypt(string key, byte[] input) {
            return base.Channel.TEABitmapDecrypt(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> TEABitmapDecryptAsync(string key, byte[] input) {
            return base.Channel.TEABitmapDecryptAsync(key, input);
        }
        
        public byte[] TEAFileCrypt(string key, byte[] input) {
            return base.Channel.TEAFileCrypt(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> TEAFileCryptAsync(string key, byte[] input) {
            return base.Channel.TEAFileCryptAsync(key, input);
        }
        
        public byte[] TEAFileDecrypt(string key, byte[] input) {
            return base.Channel.TEAFileDecrypt(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> TEAFileDecryptAsync(string key, byte[] input) {
            return base.Channel.TEAFileDecryptAsync(key, input);
        }
        
        public string CBC_TEACrypt(string key, string input, string init_vector) {
            return base.Channel.CBC_TEACrypt(key, input, init_vector);
        }
        
        public System.Threading.Tasks.Task<string> CBC_TEACryptAsync(string key, string input, string init_vector) {
            return base.Channel.CBC_TEACryptAsync(key, input, init_vector);
        }
        
        public string CBC_TEADecrypt(string key, string input, string init_vector) {
            return base.Channel.CBC_TEADecrypt(key, input, init_vector);
        }
        
        public System.Threading.Tasks.Task<string> CBC_TEADecryptAsync(string key, string input, string init_vector) {
            return base.Channel.CBC_TEADecryptAsync(key, input, init_vector);
        }
    }
}
