﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api2connect.arvatoControl {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="arvatoControl.arvatocontrolSoap")]
    public interface arvatocontrolSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertarEvento", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(StructuralObject))]
        Api2connect.arvatoControl.resultadoEvento insertarEvento(int idAplicacion, int idTipoEvento, int idAccion, string modulo, string descripcion, string resultado, string ipCliente, string usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertarDetalle", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(StructuralObject))]
        Api2connect.arvatoControl.resultadoEvento insertarDetalle(long evento, string prefijo, string variable, string valor);
        
        // CODEGEN: El parámetro 'IdEvento' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/consultarEventos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(StructuralObject))]
        Api2connect.arvatoControl.consultarEventosResponse consultarEventos(Api2connect.arvatoControl.consultarEventosRequest request);
        
        // CODEGEN: El parámetro 'IdDetalle' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/consultarDetalles", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(StructuralObject))]
        Api2connect.arvatoControl.consultarDetallesResponse consultarDetalles(Api2connect.arvatoControl.consultarDetallesRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class resultadoEvento : object, System.ComponentModel.INotifyPropertyChanged {
        
        private long resultadoField;
        
        private string prefijoField;
        
        private string mensajeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public long resultado {
            get {
                return this.resultadoField;
            }
            set {
                this.resultadoField = value;
                this.RaisePropertyChanged("resultado");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string prefijo {
            get {
                return this.prefijoField;
            }
            set {
                this.prefijoField = value;
                this.RaisePropertyChanged("prefijo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string mensaje {
            get {
                return this.mensajeField;
            }
            set {
                this.mensajeField = value;
                this.RaisePropertyChanged("mensaje");
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplexObject))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SP_Consultar_Detalles_Result))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SP_Consultar_Eventos_Result))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class StructuralObject : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SP_Consultar_Detalles_Result))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SP_Consultar_Eventos_Result))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class ComplexObject : StructuralObject {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class SP_Consultar_Detalles_Result : ComplexObject {
        
        private long iDDetalleField;
        
        private System.Nullable<long> iDEventoField;
        
        private string prefijoField;
        
        private string variableField;
        
        private string valorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public long IDDetalle {
            get {
                return this.iDDetalleField;
            }
            set {
                this.iDDetalleField = value;
                this.RaisePropertyChanged("IDDetalle");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
        public System.Nullable<long> IDEvento {
            get {
                return this.iDEventoField;
            }
            set {
                this.iDEventoField = value;
                this.RaisePropertyChanged("IDEvento");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Prefijo {
            get {
                return this.prefijoField;
            }
            set {
                this.prefijoField = value;
                this.RaisePropertyChanged("Prefijo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Variable {
            get {
                return this.variableField;
            }
            set {
                this.variableField = value;
                this.RaisePropertyChanged("Variable");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Valor {
            get {
                return this.valorField;
            }
            set {
                this.valorField = value;
                this.RaisePropertyChanged("Valor");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class SP_Consultar_Eventos_Result : ComplexObject {
        
        private long iDEventoField;
        
        private string prefijoField;
        
        private System.Nullable<int> iDAplicacionField;
        
        private System.Nullable<int> iDTipoEventoField;
        
        private System.Nullable<int> iDAccionField;
        
        private string moduloField;
        
        private string descripcionField;
        
        private string resultadoField;
        
        private System.Nullable<System.DateTime> fechaField;
        
        private string iPServidorField;
        
        private string iPClienteField;
        
        private string usuarioField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public long IDEvento {
            get {
                return this.iDEventoField;
            }
            set {
                this.iDEventoField = value;
                this.RaisePropertyChanged("IDEvento");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Prefijo {
            get {
                return this.prefijoField;
            }
            set {
                this.prefijoField = value;
                this.RaisePropertyChanged("Prefijo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        public System.Nullable<int> IDAplicacion {
            get {
                return this.iDAplicacionField;
            }
            set {
                this.iDAplicacionField = value;
                this.RaisePropertyChanged("IDAplicacion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
        public System.Nullable<int> IDTipoEvento {
            get {
                return this.iDTipoEventoField;
            }
            set {
                this.iDTipoEventoField = value;
                this.RaisePropertyChanged("IDTipoEvento");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=4)]
        public System.Nullable<int> IDAccion {
            get {
                return this.iDAccionField;
            }
            set {
                this.iDAccionField = value;
                this.RaisePropertyChanged("IDAccion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Modulo {
            get {
                return this.moduloField;
            }
            set {
                this.moduloField = value;
                this.RaisePropertyChanged("Modulo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("Descripcion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Resultado {
            get {
                return this.resultadoField;
            }
            set {
                this.resultadoField = value;
                this.RaisePropertyChanged("Resultado");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=8)]
        public System.Nullable<System.DateTime> Fecha {
            get {
                return this.fechaField;
            }
            set {
                this.fechaField = value;
                this.RaisePropertyChanged("Fecha");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string IPServidor {
            get {
                return this.iPServidorField;
            }
            set {
                this.iPServidorField = value;
                this.RaisePropertyChanged("IPServidor");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string IPCliente {
            get {
                return this.iPClienteField;
            }
            set {
                this.iPClienteField = value;
                this.RaisePropertyChanged("IPCliente");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string Usuario {
            get {
                return this.usuarioField;
            }
            set {
                this.usuarioField = value;
                this.RaisePropertyChanged("Usuario");
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarEventos", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class consultarEventosRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<long> IdEvento;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string Prefijo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> IdAplicacion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> IdTipoEvento;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> IdAccion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=5)]
        public string Modulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=6)]
        public string Descripcion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=7)]
        public string Resultado;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=8)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> FechaDesde;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=9)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> FechaHasta;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=10)]
        public string IpServidor;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=11)]
        public string IpCliente;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=12)]
        public string Usuario;
        
        public consultarEventosRequest() {
        }
        
        public consultarEventosRequest(System.Nullable<long> IdEvento, string Prefijo, System.Nullable<int> IdAplicacion, System.Nullable<int> IdTipoEvento, System.Nullable<int> IdAccion, string Modulo, string Descripcion, string Resultado, System.Nullable<System.DateTime> FechaDesde, System.Nullable<System.DateTime> FechaHasta, string IpServidor, string IpCliente, string Usuario) {
            this.IdEvento = IdEvento;
            this.Prefijo = Prefijo;
            this.IdAplicacion = IdAplicacion;
            this.IdTipoEvento = IdTipoEvento;
            this.IdAccion = IdAccion;
            this.Modulo = Modulo;
            this.Descripcion = Descripcion;
            this.Resultado = Resultado;
            this.FechaDesde = FechaDesde;
            this.FechaHasta = FechaHasta;
            this.IpServidor = IpServidor;
            this.IpCliente = IpCliente;
            this.Usuario = Usuario;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarEventosResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class consultarEventosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Api2connect.arvatoControl.SP_Consultar_Eventos_Result[] consultarEventosResult;
        
        public consultarEventosResponse() {
        }
        
        public consultarEventosResponse(Api2connect.arvatoControl.SP_Consultar_Eventos_Result[] consultarEventosResult) {
            this.consultarEventosResult = consultarEventosResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarDetalles", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class consultarDetallesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<long> IdDetalle;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<long> IdEvento;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string Prefijo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string Variable;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string Valor;
        
        public consultarDetallesRequest() {
        }
        
        public consultarDetallesRequest(System.Nullable<long> IdDetalle, System.Nullable<long> IdEvento, string Prefijo, string Variable, string Valor) {
            this.IdDetalle = IdDetalle;
            this.IdEvento = IdEvento;
            this.Prefijo = Prefijo;
            this.Variable = Variable;
            this.Valor = Valor;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarDetallesResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class consultarDetallesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Api2connect.arvatoControl.SP_Consultar_Detalles_Result[] consultarDetallesResult;
        
        public consultarDetallesResponse() {
        }
        
        public consultarDetallesResponse(Api2connect.arvatoControl.SP_Consultar_Detalles_Result[] consultarDetallesResult) {
            this.consultarDetallesResult = consultarDetallesResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface arvatocontrolSoapChannel : Api2connect.arvatoControl.arvatocontrolSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class arvatocontrolSoapClient : System.ServiceModel.ClientBase<Api2connect.arvatoControl.arvatocontrolSoap>, Api2connect.arvatoControl.arvatocontrolSoap {
        
        public arvatocontrolSoapClient() {
        }
        
        public arvatocontrolSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public arvatocontrolSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public arvatocontrolSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public arvatocontrolSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Api2connect.arvatoControl.resultadoEvento insertarEvento(int idAplicacion, int idTipoEvento, int idAccion, string modulo, string descripcion, string resultado, string ipCliente, string usuario) {
            return base.Channel.insertarEvento(idAplicacion, idTipoEvento, idAccion, modulo, descripcion, resultado, ipCliente, usuario);
        }
        
        public Api2connect.arvatoControl.resultadoEvento insertarDetalle(long evento, string prefijo, string variable, string valor) {
            return base.Channel.insertarDetalle(evento, prefijo, variable, valor);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Api2connect.arvatoControl.consultarEventosResponse Api2connect.arvatoControl.arvatocontrolSoap.consultarEventos(Api2connect.arvatoControl.consultarEventosRequest request) {
            return base.Channel.consultarEventos(request);
        }
        
        public Api2connect.arvatoControl.SP_Consultar_Eventos_Result[] consultarEventos(System.Nullable<long> IdEvento, string Prefijo, System.Nullable<int> IdAplicacion, System.Nullable<int> IdTipoEvento, System.Nullable<int> IdAccion, string Modulo, string Descripcion, string Resultado, System.Nullable<System.DateTime> FechaDesde, System.Nullable<System.DateTime> FechaHasta, string IpServidor, string IpCliente, string Usuario) {
            Api2connect.arvatoControl.consultarEventosRequest inValue = new Api2connect.arvatoControl.consultarEventosRequest();
            inValue.IdEvento = IdEvento;
            inValue.Prefijo = Prefijo;
            inValue.IdAplicacion = IdAplicacion;
            inValue.IdTipoEvento = IdTipoEvento;
            inValue.IdAccion = IdAccion;
            inValue.Modulo = Modulo;
            inValue.Descripcion = Descripcion;
            inValue.Resultado = Resultado;
            inValue.FechaDesde = FechaDesde;
            inValue.FechaHasta = FechaHasta;
            inValue.IpServidor = IpServidor;
            inValue.IpCliente = IpCliente;
            inValue.Usuario = Usuario;
            Api2connect.arvatoControl.consultarEventosResponse retVal = ((Api2connect.arvatoControl.arvatocontrolSoap)(this)).consultarEventos(inValue);
            return retVal.consultarEventosResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Api2connect.arvatoControl.consultarDetallesResponse Api2connect.arvatoControl.arvatocontrolSoap.consultarDetalles(Api2connect.arvatoControl.consultarDetallesRequest request) {
            return base.Channel.consultarDetalles(request);
        }
        
        public Api2connect.arvatoControl.SP_Consultar_Detalles_Result[] consultarDetalles(System.Nullable<long> IdDetalle, System.Nullable<long> IdEvento, string Prefijo, string Variable, string Valor) {
            Api2connect.arvatoControl.consultarDetallesRequest inValue = new Api2connect.arvatoControl.consultarDetallesRequest();
            inValue.IdDetalle = IdDetalle;
            inValue.IdEvento = IdEvento;
            inValue.Prefijo = Prefijo;
            inValue.Variable = Variable;
            inValue.Valor = Valor;
            Api2connect.arvatoControl.consultarDetallesResponse retVal = ((Api2connect.arvatoControl.arvatocontrolSoap)(this)).consultarDetalles(inValue);
            return retVal.consultarDetallesResult;
        }
    }
}
