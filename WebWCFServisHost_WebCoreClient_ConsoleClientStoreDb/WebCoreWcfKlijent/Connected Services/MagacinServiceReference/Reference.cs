﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagacinServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Runtime.Serialization.DataContractAttribute(Name="KategorijaCon", Namespace="http://schemas.datacontract.org/2004/07/WebWCFServisHost.Models")]
    public partial class KategorijaCon : object
    {
        
        private int KategorijaIdField;
        
        private string NazivKategorijeField;
        
        private string OpisKategorijeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int KategorijaId
        {
            get
            {
                return this.KategorijaIdField;
            }
            set
            {
                this.KategorijaIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NazivKategorije
        {
            get
            {
                return this.NazivKategorijeField;
            }
            set
            {
                this.NazivKategorijeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OpisKategorije
        {
            get
            {
                return this.OpisKategorijeField;
            }
            set
            {
                this.OpisKategorijeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProizvodCon", Namespace="http://schemas.datacontract.org/2004/07/WebWCFServisHost.Models")]
    public partial class ProizvodCon : object
    {
        
        private decimal CijenaField;
        
        private int KategorijaIdField;
        
        private int KolicinaNaLageruField;
        
        private string NazivProizvodaField;
        
        private int ProizvodIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Cijena
        {
            get
            {
                return this.CijenaField;
            }
            set
            {
                this.CijenaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int KategorijaId
        {
            get
            {
                return this.KategorijaIdField;
            }
            set
            {
                this.KategorijaIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int KolicinaNaLageru
        {
            get
            {
                return this.KolicinaNaLageruField;
            }
            set
            {
                this.KolicinaNaLageruField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NazivProizvoda
        {
            get
            {
                return this.NazivProizvodaField;
            }
            set
            {
                this.NazivProizvodaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProizvodId
        {
            get
            {
                return this.ProizvodIdField;
            }
            set
            {
                this.ProizvodIdField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MagacinServiceReference.IMagacinService")]
    public interface IMagacinService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMagacinService/VratiKategorije", ReplyAction="http://tempuri.org/IMagacinService/VratiKategorijeResponse")]
        System.Threading.Tasks.Task<MagacinServiceReference.KategorijaCon[]> VratiKategorijeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMagacinService/VratiKategoriju", ReplyAction="http://tempuri.org/IMagacinService/VratiKategorijuResponse")]
        System.Threading.Tasks.Task<MagacinServiceReference.KategorijaCon> VratiKategorijuAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMagacinService/VratiProizvode", ReplyAction="http://tempuri.org/IMagacinService/VratiProizvodeResponse")]
        System.Threading.Tasks.Task<MagacinServiceReference.ProizvodCon[]> VratiProizvodeAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    public interface IMagacinServiceChannel : MagacinServiceReference.IMagacinService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    public partial class MagacinServiceClient : System.ServiceModel.ClientBase<MagacinServiceReference.IMagacinService>, MagacinServiceReference.IMagacinService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public MagacinServiceClient() : 
                base(MagacinServiceClient.GetDefaultBinding(), MagacinServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IMagacinService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MagacinServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(MagacinServiceClient.GetBindingForEndpoint(endpointConfiguration), MagacinServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MagacinServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(MagacinServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MagacinServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(MagacinServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MagacinServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<MagacinServiceReference.KategorijaCon[]> VratiKategorijeAsync()
        {
            return base.Channel.VratiKategorijeAsync();
        }
        
        public System.Threading.Tasks.Task<MagacinServiceReference.KategorijaCon> VratiKategorijuAsync(int id)
        {
            return base.Channel.VratiKategorijuAsync(id);
        }
        
        public System.Threading.Tasks.Task<MagacinServiceReference.ProizvodCon[]> VratiProizvodeAsync(int id)
        {
            return base.Channel.VratiProizvodeAsync(id);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IMagacinService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IMagacinService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:61560/MagacinService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return MagacinServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IMagacinService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return MagacinServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IMagacinService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IMagacinService,
        }
    }
}
