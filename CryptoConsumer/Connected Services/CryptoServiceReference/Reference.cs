﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CryptoConsumer.CryptoServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CryptoServiceReference.ICryptoProvider")]
    public interface ICryptoProvider {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_EncryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_EncryptFileResponse")]
        byte[] RC4_EncryptFile(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_EncryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_EncryptFileResponse")]
        System.Threading.Tasks.Task<byte[]> RC4_EncryptFileAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_DecryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_DecryptFileResponse")]
        byte[] RC4_DecryptFile(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_DecryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_DecryptFileResponse")]
        System.Threading.Tasks.Task<byte[]> RC4_DecryptFileAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_EncryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_EncryptBitmapResponse")]
        byte[] RC4_EncryptBitmap(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_EncryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_EncryptBitmapResponse")]
        System.Threading.Tasks.Task<byte[]> RC4_EncryptBitmapAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_DecryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_DecryptBitmapResponse")]
        byte[] RC4_DecryptBitmap(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_DecryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_DecryptBitmapResponse")]
        System.Threading.Tasks.Task<byte[]> RC4_DecryptBitmapAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_EncryptText", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_EncryptTextResponse")]
        string[] RC4_EncryptText(string key, string[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_EncryptText", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_EncryptTextResponse")]
        System.Threading.Tasks.Task<string[]> RC4_EncryptTextAsync(string key, string[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_DecryptText", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_DecryptTextResponse")]
        string[] RC4_DecryptText(string key, string[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_DecryptText", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_DecryptTextResponse")]
        System.Threading.Tasks.Task<string[]> RC4_DecryptTextAsync(string key, string[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_EncryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_EncryptPlaintextResponse")]
        string RC4_EncryptPlaintext(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_EncryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_EncryptPlaintextResponse")]
        System.Threading.Tasks.Task<string> RC4_EncryptPlaintextAsync(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_DecryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_DecryptPlaintextResponse")]
        string RC4_DecryptPlaintext(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/RC4_DecryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/RC4_DecryptPlaintextResponse")]
        System.Threading.Tasks.Task<string> RC4_DecryptPlaintextAsync(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_EncryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_EncryptFileResponse")]
        byte[] TEA_EncryptFile(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_EncryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_EncryptFileResponse")]
        System.Threading.Tasks.Task<byte[]> TEA_EncryptFileAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_DecryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_DecryptFileResponse")]
        byte[] TEA_DecryptFile(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_DecryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_DecryptFileResponse")]
        System.Threading.Tasks.Task<byte[]> TEA_DecryptFileAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_EncryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_EncryptBitmapResponse")]
        byte[] TEA_EncryptBitmap(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_EncryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_EncryptBitmapResponse")]
        System.Threading.Tasks.Task<byte[]> TEA_EncryptBitmapAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_DecryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_DecryptBitmapResponse")]
        byte[] TEA_DecryptBitmap(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_DecryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_DecryptBitmapResponse")]
        System.Threading.Tasks.Task<byte[]> TEA_DecryptBitmapAsync(string key, byte[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_EncryptText", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_EncryptTextResponse")]
        string[] TEA_EncryptText(string key, string[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_EncryptText", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_EncryptTextResponse")]
        System.Threading.Tasks.Task<string[]> TEA_EncryptTextAsync(string key, string[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_DecryptText", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_DecryptTextResponse")]
        string[] TEA_DecryptText(string key, string[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_DecryptText", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_DecryptTextResponse")]
        System.Threading.Tasks.Task<string[]> TEA_DecryptTextAsync(string key, string[] input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_EncryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_EncryptPlaintextResponse")]
        string TEA_EncryptPlaintext(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_EncryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_EncryptPlaintextResponse")]
        System.Threading.Tasks.Task<string> TEA_EncryptPlaintextAsync(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_DecryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_DecryptPlaintextResponse")]
        string TEA_DecryptPlaintext(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/TEA_DecryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/TEA_DecryptPlaintextResponse")]
        System.Threading.Tasks.Task<string> TEA_DecryptPlaintextAsync(string key, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_EncryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_EncryptFileResponse")]
        byte[] CBC_EncryptFile(string key, byte[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_EncryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_EncryptFileResponse")]
        System.Threading.Tasks.Task<byte[]> CBC_EncryptFileAsync(string key, byte[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_DecryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_DecryptFileResponse")]
        byte[] CBC_DecryptFile(string key, byte[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_DecryptFile", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_DecryptFileResponse")]
        System.Threading.Tasks.Task<byte[]> CBC_DecryptFileAsync(string key, byte[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_EncryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_EncryptBitmapResponse")]
        byte[] CBC_EncryptBitmap(string key, byte[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_EncryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_EncryptBitmapResponse")]
        System.Threading.Tasks.Task<byte[]> CBC_EncryptBitmapAsync(string key, byte[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_DecryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_DecryptBitmapResponse")]
        byte[] CBC_DecryptBitmap(string key, byte[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_DecryptBitmap", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_DecryptBitmapResponse")]
        System.Threading.Tasks.Task<byte[]> CBC_DecryptBitmapAsync(string key, byte[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_EncryptText", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_EncryptTextResponse")]
        string[] CBC_EncryptText(string key, string[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_EncryptText", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_EncryptTextResponse")]
        System.Threading.Tasks.Task<string[]> CBC_EncryptTextAsync(string key, string[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_DecryptText", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_DecryptTextResponse")]
        string[] CBC_DecryptText(string key, string[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_DecryptText", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_DecryptTextResponse")]
        System.Threading.Tasks.Task<string[]> CBC_DecryptTextAsync(string key, string[] input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_EncryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_EncryptPlaintextResponse")]
        string CBC_EncryptPlaintext(string key, string input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_EncryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_EncryptPlaintextResponse")]
        System.Threading.Tasks.Task<string> CBC_EncryptPlaintextAsync(string key, string input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_DecryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_DecryptPlaintextResponse")]
        string CBC_DecryptPlaintext(string key, string input, string initialization_vector);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/CBC_DecryptPlaintext", ReplyAction="http://tempuri.org/ICryptoProvider/CBC_DecryptPlaintextResponse")]
        System.Threading.Tasks.Task<string> CBC_DecryptPlaintextAsync(string key, string input, string initialization_vector);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICryptoProviderChannel : CryptoConsumer.CryptoServiceReference.ICryptoProvider, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CryptoProviderClient : System.ServiceModel.ClientBase<CryptoConsumer.CryptoServiceReference.ICryptoProvider>, CryptoConsumer.CryptoServiceReference.ICryptoProvider {
        
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
        
        public byte[] RC4_EncryptFile(string key, byte[] input) {
            return base.Channel.RC4_EncryptFile(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> RC4_EncryptFileAsync(string key, byte[] input) {
            return base.Channel.RC4_EncryptFileAsync(key, input);
        }
        
        public byte[] RC4_DecryptFile(string key, byte[] input) {
            return base.Channel.RC4_DecryptFile(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> RC4_DecryptFileAsync(string key, byte[] input) {
            return base.Channel.RC4_DecryptFileAsync(key, input);
        }
        
        public byte[] RC4_EncryptBitmap(string key, byte[] input) {
            return base.Channel.RC4_EncryptBitmap(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> RC4_EncryptBitmapAsync(string key, byte[] input) {
            return base.Channel.RC4_EncryptBitmapAsync(key, input);
        }
        
        public byte[] RC4_DecryptBitmap(string key, byte[] input) {
            return base.Channel.RC4_DecryptBitmap(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> RC4_DecryptBitmapAsync(string key, byte[] input) {
            return base.Channel.RC4_DecryptBitmapAsync(key, input);
        }
        
        public string[] RC4_EncryptText(string key, string[] input) {
            return base.Channel.RC4_EncryptText(key, input);
        }
        
        public System.Threading.Tasks.Task<string[]> RC4_EncryptTextAsync(string key, string[] input) {
            return base.Channel.RC4_EncryptTextAsync(key, input);
        }
        
        public string[] RC4_DecryptText(string key, string[] input) {
            return base.Channel.RC4_DecryptText(key, input);
        }
        
        public System.Threading.Tasks.Task<string[]> RC4_DecryptTextAsync(string key, string[] input) {
            return base.Channel.RC4_DecryptTextAsync(key, input);
        }
        
        public string RC4_EncryptPlaintext(string key, string input) {
            return base.Channel.RC4_EncryptPlaintext(key, input);
        }
        
        public System.Threading.Tasks.Task<string> RC4_EncryptPlaintextAsync(string key, string input) {
            return base.Channel.RC4_EncryptPlaintextAsync(key, input);
        }
        
        public string RC4_DecryptPlaintext(string key, string input) {
            return base.Channel.RC4_DecryptPlaintext(key, input);
        }
        
        public System.Threading.Tasks.Task<string> RC4_DecryptPlaintextAsync(string key, string input) {
            return base.Channel.RC4_DecryptPlaintextAsync(key, input);
        }
        
        public byte[] TEA_EncryptFile(string key, byte[] input) {
            return base.Channel.TEA_EncryptFile(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> TEA_EncryptFileAsync(string key, byte[] input) {
            return base.Channel.TEA_EncryptFileAsync(key, input);
        }
        
        public byte[] TEA_DecryptFile(string key, byte[] input) {
            return base.Channel.TEA_DecryptFile(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> TEA_DecryptFileAsync(string key, byte[] input) {
            return base.Channel.TEA_DecryptFileAsync(key, input);
        }
        
        public byte[] TEA_EncryptBitmap(string key, byte[] input) {
            return base.Channel.TEA_EncryptBitmap(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> TEA_EncryptBitmapAsync(string key, byte[] input) {
            return base.Channel.TEA_EncryptBitmapAsync(key, input);
        }
        
        public byte[] TEA_DecryptBitmap(string key, byte[] input) {
            return base.Channel.TEA_DecryptBitmap(key, input);
        }
        
        public System.Threading.Tasks.Task<byte[]> TEA_DecryptBitmapAsync(string key, byte[] input) {
            return base.Channel.TEA_DecryptBitmapAsync(key, input);
        }
        
        public string[] TEA_EncryptText(string key, string[] input) {
            return base.Channel.TEA_EncryptText(key, input);
        }
        
        public System.Threading.Tasks.Task<string[]> TEA_EncryptTextAsync(string key, string[] input) {
            return base.Channel.TEA_EncryptTextAsync(key, input);
        }
        
        public string[] TEA_DecryptText(string key, string[] input) {
            return base.Channel.TEA_DecryptText(key, input);
        }
        
        public System.Threading.Tasks.Task<string[]> TEA_DecryptTextAsync(string key, string[] input) {
            return base.Channel.TEA_DecryptTextAsync(key, input);
        }
        
        public string TEA_EncryptPlaintext(string key, string input) {
            return base.Channel.TEA_EncryptPlaintext(key, input);
        }
        
        public System.Threading.Tasks.Task<string> TEA_EncryptPlaintextAsync(string key, string input) {
            return base.Channel.TEA_EncryptPlaintextAsync(key, input);
        }
        
        public string TEA_DecryptPlaintext(string key, string input) {
            return base.Channel.TEA_DecryptPlaintext(key, input);
        }
        
        public System.Threading.Tasks.Task<string> TEA_DecryptPlaintextAsync(string key, string input) {
            return base.Channel.TEA_DecryptPlaintextAsync(key, input);
        }
        
        public byte[] CBC_EncryptFile(string key, byte[] input, string initialization_vector) {
            return base.Channel.CBC_EncryptFile(key, input, initialization_vector);
        }
        
        public System.Threading.Tasks.Task<byte[]> CBC_EncryptFileAsync(string key, byte[] input, string initialization_vector) {
            return base.Channel.CBC_EncryptFileAsync(key, input, initialization_vector);
        }
        
        public byte[] CBC_DecryptFile(string key, byte[] input, string initialization_vector) {
            return base.Channel.CBC_DecryptFile(key, input, initialization_vector);
        }
        
        public System.Threading.Tasks.Task<byte[]> CBC_DecryptFileAsync(string key, byte[] input, string initialization_vector) {
            return base.Channel.CBC_DecryptFileAsync(key, input, initialization_vector);
        }
        
        public byte[] CBC_EncryptBitmap(string key, byte[] input, string initialization_vector) {
            return base.Channel.CBC_EncryptBitmap(key, input, initialization_vector);
        }
        
        public System.Threading.Tasks.Task<byte[]> CBC_EncryptBitmapAsync(string key, byte[] input, string initialization_vector) {
            return base.Channel.CBC_EncryptBitmapAsync(key, input, initialization_vector);
        }
        
        public byte[] CBC_DecryptBitmap(string key, byte[] input, string initialization_vector) {
            return base.Channel.CBC_DecryptBitmap(key, input, initialization_vector);
        }
        
        public System.Threading.Tasks.Task<byte[]> CBC_DecryptBitmapAsync(string key, byte[] input, string initialization_vector) {
            return base.Channel.CBC_DecryptBitmapAsync(key, input, initialization_vector);
        }
        
        public string[] CBC_EncryptText(string key, string[] input, string initialization_vector) {
            return base.Channel.CBC_EncryptText(key, input, initialization_vector);
        }
        
        public System.Threading.Tasks.Task<string[]> CBC_EncryptTextAsync(string key, string[] input, string initialization_vector) {
            return base.Channel.CBC_EncryptTextAsync(key, input, initialization_vector);
        }
        
        public string[] CBC_DecryptText(string key, string[] input, string initialization_vector) {
            return base.Channel.CBC_DecryptText(key, input, initialization_vector);
        }
        
        public System.Threading.Tasks.Task<string[]> CBC_DecryptTextAsync(string key, string[] input, string initialization_vector) {
            return base.Channel.CBC_DecryptTextAsync(key, input, initialization_vector);
        }
        
        public string CBC_EncryptPlaintext(string key, string input, string initialization_vector) {
            return base.Channel.CBC_EncryptPlaintext(key, input, initialization_vector);
        }
        
        public System.Threading.Tasks.Task<string> CBC_EncryptPlaintextAsync(string key, string input, string initialization_vector) {
            return base.Channel.CBC_EncryptPlaintextAsync(key, input, initialization_vector);
        }
        
        public string CBC_DecryptPlaintext(string key, string input, string initialization_vector) {
            return base.Channel.CBC_DecryptPlaintext(key, input, initialization_vector);
        }
        
        public System.Threading.Tasks.Task<string> CBC_DecryptPlaintextAsync(string key, string input, string initialization_vector) {
            return base.Channel.CBC_DecryptPlaintextAsync(key, input, initialization_vector);
        }
    }
}
