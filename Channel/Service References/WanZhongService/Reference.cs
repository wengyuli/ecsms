﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECSMS.Channel.WanZhongService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WanZhongService.Service1Soap")]
    public interface Service1Soap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/g_Submit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ECSMS.Channel.WanZhongService.CSubmitState g_Submit(string sname, string spwd, string scorpid, string sprdid, string sdst, string smsg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/g_SchedulerSubmit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ECSMS.Channel.WanZhongService.CSubmitState g_SchedulerSubmit(string sname, string spwd, string scorpid, string sprdid, string sbegindate, string sdst, string smsg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VersionInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string VersionInfo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/g_QuerySendState", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ECSMS.Channel.WanZhongService.CSendState g_QuerySendState(string sname, string msgid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Sm_GetRemain", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ECSMS.Channel.WanZhongService.CRemain Sm_GetRemain(string sname, string spwd, string scorpid, string sprdid);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CSubmitState : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int stateField;
        
        private string msgIDField;
        
        private string msgStateField;
        
        private int reserveField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
                this.RaisePropertyChanged("State");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string MsgID {
            get {
                return this.msgIDField;
            }
            set {
                this.msgIDField = value;
                this.RaisePropertyChanged("MsgID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string MsgState {
            get {
                return this.msgStateField;
            }
            set {
                this.msgStateField = value;
                this.RaisePropertyChanged("MsgState");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Reserve {
            get {
                return this.reserveField;
            }
            set {
                this.reserveField = value;
                this.RaisePropertyChanged("Reserve");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CRemain : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int stateField;
        
        private int remainField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
                this.RaisePropertyChanged("State");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int Remain {
            get {
                return this.remainField;
            }
            set {
                this.remainField = value;
                this.RaisePropertyChanged("Remain");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CSendState : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int stateField;
        
        private int telNumField;
        
        private int sndNumField;
        
        private int sndErrField;
        
        private int outFailedNumField;
        
        private string msgStateField;
        
        private int reserveField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
                this.RaisePropertyChanged("State");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int TelNum {
            get {
                return this.telNumField;
            }
            set {
                this.telNumField = value;
                this.RaisePropertyChanged("TelNum");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int SndNum {
            get {
                return this.sndNumField;
            }
            set {
                this.sndNumField = value;
                this.RaisePropertyChanged("SndNum");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int SndErr {
            get {
                return this.sndErrField;
            }
            set {
                this.sndErrField = value;
                this.RaisePropertyChanged("SndErr");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int OutFailedNum {
            get {
                return this.outFailedNumField;
            }
            set {
                this.outFailedNumField = value;
                this.RaisePropertyChanged("OutFailedNum");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string MsgState {
            get {
                return this.msgStateField;
            }
            set {
                this.msgStateField = value;
                this.RaisePropertyChanged("MsgState");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int Reserve {
            get {
                return this.reserveField;
            }
            set {
                this.reserveField = value;
                this.RaisePropertyChanged("Reserve");
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
    public interface Service1SoapChannel : ECSMS.Channel.WanZhongService.Service1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1SoapClient : System.ServiceModel.ClientBase<ECSMS.Channel.WanZhongService.Service1Soap>, ECSMS.Channel.WanZhongService.Service1Soap {
        
        public Service1SoapClient() {
        }
        
        public Service1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ECSMS.Channel.WanZhongService.CSubmitState g_Submit(string sname, string spwd, string scorpid, string sprdid, string sdst, string smsg) {
            return base.Channel.g_Submit(sname, spwd, scorpid, sprdid, sdst, smsg);
        }
        
        public ECSMS.Channel.WanZhongService.CSubmitState g_SchedulerSubmit(string sname, string spwd, string scorpid, string sprdid, string sbegindate, string sdst, string smsg) {
            return base.Channel.g_SchedulerSubmit(sname, spwd, scorpid, sprdid, sbegindate, sdst, smsg);
        }
        
        public string VersionInfo() {
            return base.Channel.VersionInfo();
        }
        
        public ECSMS.Channel.WanZhongService.CSendState g_QuerySendState(string sname, string msgid) {
            return base.Channel.g_QuerySendState(sname, msgid);
        }
        
        public ECSMS.Channel.WanZhongService.CRemain Sm_GetRemain(string sname, string spwd, string scorpid, string sprdid) {
            return base.Channel.Sm_GetRemain(sname, spwd, scorpid, sprdid);
        }
    }
}
