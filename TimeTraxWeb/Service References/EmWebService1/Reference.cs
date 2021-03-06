﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeTrax.EmWebService1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmWebService1.WebService1Soap")]
    public interface WebService1Soap {
        
        // CODEGEN: Generating message contract since element name key from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProjectTitle", ReplyAction="*")]
        TimeTrax.EmWebService1.GetProjectTitleResponse GetProjectTitle(TimeTrax.EmWebService1.GetProjectTitleRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProjectTitle", ReplyAction="*")]
        System.Threading.Tasks.Task<TimeTrax.EmWebService1.GetProjectTitleResponse> GetProjectTitleAsync(TimeTrax.EmWebService1.GetProjectTitleRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetProjectTitleRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetProjectTitle", Namespace="http://tempuri.org/", Order=0)]
        public TimeTrax.EmWebService1.GetProjectTitleRequestBody Body;
        
        public GetProjectTitleRequest() {
        }
        
        public GetProjectTitleRequest(TimeTrax.EmWebService1.GetProjectTitleRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetProjectTitleRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string key;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string ProjectNo;
        
        public GetProjectTitleRequestBody() {
        }
        
        public GetProjectTitleRequestBody(string key, string ProjectNo) {
            this.key = key;
            this.ProjectNo = ProjectNo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetProjectTitleResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetProjectTitleResponse", Namespace="http://tempuri.org/", Order=0)]
        public TimeTrax.EmWebService1.GetProjectTitleResponseBody Body;
        
        public GetProjectTitleResponse() {
        }
        
        public GetProjectTitleResponse(TimeTrax.EmWebService1.GetProjectTitleResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetProjectTitleResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetProjectTitleResult;
        
        public GetProjectTitleResponseBody() {
        }
        
        public GetProjectTitleResponseBody(string GetProjectTitleResult) {
            this.GetProjectTitleResult = GetProjectTitleResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : TimeTrax.EmWebService1.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<TimeTrax.EmWebService1.WebService1Soap>, TimeTrax.EmWebService1.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TimeTrax.EmWebService1.GetProjectTitleResponse TimeTrax.EmWebService1.WebService1Soap.GetProjectTitle(TimeTrax.EmWebService1.GetProjectTitleRequest request) {
            return base.Channel.GetProjectTitle(request);
        }
        
        public string GetProjectTitle(string key, string ProjectNo) {
            TimeTrax.EmWebService1.GetProjectTitleRequest inValue = new TimeTrax.EmWebService1.GetProjectTitleRequest();
            inValue.Body = new TimeTrax.EmWebService1.GetProjectTitleRequestBody();
            inValue.Body.key = key;
            inValue.Body.ProjectNo = ProjectNo;
            TimeTrax.EmWebService1.GetProjectTitleResponse retVal = ((TimeTrax.EmWebService1.WebService1Soap)(this)).GetProjectTitle(inValue);
            return retVal.Body.GetProjectTitleResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TimeTrax.EmWebService1.GetProjectTitleResponse> TimeTrax.EmWebService1.WebService1Soap.GetProjectTitleAsync(TimeTrax.EmWebService1.GetProjectTitleRequest request) {
            return base.Channel.GetProjectTitleAsync(request);
        }
        
        public System.Threading.Tasks.Task<TimeTrax.EmWebService1.GetProjectTitleResponse> GetProjectTitleAsync(string key, string ProjectNo) {
            TimeTrax.EmWebService1.GetProjectTitleRequest inValue = new TimeTrax.EmWebService1.GetProjectTitleRequest();
            inValue.Body = new TimeTrax.EmWebService1.GetProjectTitleRequestBody();
            inValue.Body.key = key;
            inValue.Body.ProjectNo = ProjectNo;
            return ((TimeTrax.EmWebService1.WebService1Soap)(this)).GetProjectTitleAsync(inValue);
        }
    }
}
