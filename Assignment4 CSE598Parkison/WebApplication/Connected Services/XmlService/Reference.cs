﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.XmlService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="XmlService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/verification", ReplyAction="http://tempuri.org/IService1/verificationResponse")]
        string verification(string xmlUrl, string xsdUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/verification", ReplyAction="http://tempuri.org/IService1/verificationResponse")]
        System.Threading.Tasks.Task<string> verificationAsync(string xmlUrl, string xsdUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/search", ReplyAction="http://tempuri.org/IService1/searchResponse")]
        string search(string xmlUrl, string key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/search", ReplyAction="http://tempuri.org/IService1/searchResponse")]
        System.Threading.Tasks.Task<string> searchAsync(string xmlUrl, string key);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WebApplication.XmlService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WebApplication.XmlService.IService1>, WebApplication.XmlService.IService1 {
        
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
        
        public string verification(string xmlUrl, string xsdUrl) {
            return base.Channel.verification(xmlUrl, xsdUrl);
        }
        
        public System.Threading.Tasks.Task<string> verificationAsync(string xmlUrl, string xsdUrl) {
            return base.Channel.verificationAsync(xmlUrl, xsdUrl);
        }
        
        public string search(string xmlUrl, string key) {
            return base.Channel.search(xmlUrl, key);
        }
        
        public System.Threading.Tasks.Task<string> searchAsync(string xmlUrl, string key) {
            return base.Channel.searchAsync(xmlUrl, key);
        }
    }
}
