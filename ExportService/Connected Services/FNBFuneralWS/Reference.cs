﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExportService.FNBFuneralWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://v1.fnblife.fnb.co.za/", ConfigurationName="FNBFuneralWS.FNBLifeServices")]
    public interface FNBLifeServices {
        
        // CODEGEN: Generating message contract since element name arg0 from namespace  is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        ExportService.FNBFuneralWS.genericRequestResponse genericRequest(ExportService.FNBFuneralWS.genericRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<ExportService.FNBFuneralWS.genericRequestResponse> genericRequestAsync(ExportService.FNBFuneralWS.genericRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class genericRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="genericRequest", Namespace="http://v1.fnblife.fnb.co.za/", Order=0)]
        public ExportService.FNBFuneralWS.genericRequestBody Body;
        
        public genericRequest() {
        }
        
        public genericRequest(ExportService.FNBFuneralWS.genericRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class genericRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string arg1;
        
        public genericRequestBody() {
        }
        
        public genericRequestBody(string arg0, string arg1) {
            this.arg0 = arg0;
            this.arg1 = arg1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class genericRequestResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="genericRequestResponse", Namespace="http://v1.fnblife.fnb.co.za/", Order=0)]
        public ExportService.FNBFuneralWS.genericRequestResponseBody Body;
        
        public genericRequestResponse() {
        }
        
        public genericRequestResponse(ExportService.FNBFuneralWS.genericRequestResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class genericRequestResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public genericRequestResponseBody() {
        }
        
        public genericRequestResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FNBLifeServicesChannel : ExportService.FNBFuneralWS.FNBLifeServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FNBLifeServicesClient : System.ServiceModel.ClientBase<ExportService.FNBFuneralWS.FNBLifeServices>, ExportService.FNBFuneralWS.FNBLifeServices {
        
        public FNBLifeServicesClient() {
        }
        
        public FNBLifeServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FNBLifeServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FNBLifeServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FNBLifeServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ExportService.FNBFuneralWS.genericRequestResponse ExportService.FNBFuneralWS.FNBLifeServices.genericRequest(ExportService.FNBFuneralWS.genericRequest request) {
            return base.Channel.genericRequest(request);
        }
        
        public string genericRequest(string arg0, string arg1) {
            ExportService.FNBFuneralWS.genericRequest inValue = new ExportService.FNBFuneralWS.genericRequest();
            inValue.Body = new ExportService.FNBFuneralWS.genericRequestBody();
            inValue.Body.arg0 = arg0;
            inValue.Body.arg1 = arg1;
            ExportService.FNBFuneralWS.genericRequestResponse retVal = ((ExportService.FNBFuneralWS.FNBLifeServices)(this)).genericRequest(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ExportService.FNBFuneralWS.genericRequestResponse> ExportService.FNBFuneralWS.FNBLifeServices.genericRequestAsync(ExportService.FNBFuneralWS.genericRequest request) {
            return base.Channel.genericRequestAsync(request);
        }
        
        public System.Threading.Tasks.Task<ExportService.FNBFuneralWS.genericRequestResponse> genericRequestAsync(string arg0, string arg1) {
            ExportService.FNBFuneralWS.genericRequest inValue = new ExportService.FNBFuneralWS.genericRequest();
            inValue.Body = new ExportService.FNBFuneralWS.genericRequestBody();
            inValue.Body.arg0 = arg0;
            inValue.Body.arg1 = arg1;
            return ((ExportService.FNBFuneralWS.FNBLifeServices)(this)).genericRequestAsync(inValue);
        }
    }
}
