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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/EnigmaCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/EnigmaCryptResponse")]
        string EnigmaCrypt(CryptoProvider.EnigmaState state, string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICryptoProvider/EnigmaCrypt", ReplyAction="http://tempuri.org/ICryptoProvider/EnigmaCryptResponse")]
        System.Threading.Tasks.Task<string> EnigmaCryptAsync(CryptoProvider.EnigmaState state, string input);
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
        
        public string EnigmaCrypt(CryptoProvider.EnigmaState state, string input) {
            return base.Channel.EnigmaCrypt(state, input);
        }
        
        public System.Threading.Tasks.Task<string> EnigmaCryptAsync(CryptoProvider.EnigmaState state, string input) {
            return base.Channel.EnigmaCryptAsync(state, input);
        }
    }
}
