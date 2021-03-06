﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment5.EncryptionService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EncryptionService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/encrypt", ReplyAction="http://tempuri.org/IService1/encryptResponse")]
        string encrypt(string clearText);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/encrypt", ReplyAction="http://tempuri.org/IService1/encryptResponse")]
        System.Threading.Tasks.Task<string> encryptAsync(string clearText);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/decrypt", ReplyAction="http://tempuri.org/IService1/decryptResponse")]
        string decrypt(string cipherText);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/decrypt", ReplyAction="http://tempuri.org/IService1/decryptResponse")]
        System.Threading.Tasks.Task<string> decryptAsync(string cipherText);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Assignment5.EncryptionService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Assignment5.EncryptionService.IService1>, Assignment5.EncryptionService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string encrypt(string clearText) {
            return base.Channel.encrypt(clearText);
        }
        
        public System.Threading.Tasks.Task<string> encryptAsync(string clearText) {
            return base.Channel.encryptAsync(clearText);
        }
        
        public string decrypt(string cipherText) {
            return base.Channel.decrypt(cipherText);
        }
        
        public System.Threading.Tasks.Task<string> decryptAsync(string cipherText) {
            return base.Channel.decryptAsync(cipherText);
        }
    }
}
