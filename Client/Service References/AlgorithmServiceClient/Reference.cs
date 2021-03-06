﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.AlgorithmServiceClient {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/WcfServices")]
    [System.SerializableAttribute()]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LengthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int[] NodesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Length {
            get {
                return this.LengthField;
            }
            set {
                if ((this.LengthField.Equals(value) != true)) {
                    this.LengthField = value;
                    this.RaisePropertyChanged("Length");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] Nodes {
            get {
                return this.NodesField;
            }
            set {
                if ((object.ReferenceEquals(this.NodesField, value) != true)) {
                    this.NodesField = value;
                    this.RaisePropertyChanged("Nodes");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AlgorithmServiceClient.IAlgorithmService")]
    public interface IAlgorithmService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlgorithmService/GetShortestPath", ReplyAction="http://tempuri.org/IAlgorithmService/GetShortestPathResponse")]
        Client.AlgorithmServiceClient.Result GetShortestPath(int node1, int node2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlgorithmService/GetShortestPath", ReplyAction="http://tempuri.org/IAlgorithmService/GetShortestPathResponse")]
        System.Threading.Tasks.Task<Client.AlgorithmServiceClient.Result> GetShortestPathAsync(int node1, int node2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlgorithmServiceChannel : Client.AlgorithmServiceClient.IAlgorithmService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlgorithmServiceClient : System.ServiceModel.ClientBase<Client.AlgorithmServiceClient.IAlgorithmService>, Client.AlgorithmServiceClient.IAlgorithmService {
        
        public AlgorithmServiceClient() {
        }
        
        public AlgorithmServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AlgorithmServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlgorithmServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlgorithmServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.AlgorithmServiceClient.Result GetShortestPath(int node1, int node2) {
            return base.Channel.GetShortestPath(node1, node2);
        }
        
        public System.Threading.Tasks.Task<Client.AlgorithmServiceClient.Result> GetShortestPathAsync(int node1, int node2) {
            return base.Channel.GetShortestPathAsync(node1, node2);
        }
    }
}
