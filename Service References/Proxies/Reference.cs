﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18051
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace Discount.Proxies {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CProduct", Namespace="http://schemas.datacontract.org/2004/07/WcfDiscount")]
    public partial class CProduct : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string discountField;
        
        private string endDateField;
        
        private string imageURLField;
        
        private string newPriceField;
        
        private string oldPriceField;
        
        private string productIDField;
        
        private string productNameField;
        
        private string startDateField;
        
        private string storeIDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string discount {
            get {
                return this.discountField;
            }
            set {
                if ((object.ReferenceEquals(this.discountField, value) != true)) {
                    this.discountField = value;
                    this.RaisePropertyChanged("discount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string endDate {
            get {
                return this.endDateField;
            }
            set {
                if ((object.ReferenceEquals(this.endDateField, value) != true)) {
                    this.endDateField = value;
                    this.RaisePropertyChanged("endDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string imageURL {
            get {
                return this.imageURLField;
            }
            set {
                if ((object.ReferenceEquals(this.imageURLField, value) != true)) {
                    this.imageURLField = value;
                    this.RaisePropertyChanged("imageURL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string newPrice {
            get {
                return this.newPriceField;
            }
            set {
                if ((object.ReferenceEquals(this.newPriceField, value) != true)) {
                    this.newPriceField = value;
                    this.RaisePropertyChanged("newPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string oldPrice {
            get {
                return this.oldPriceField;
            }
            set {
                if ((object.ReferenceEquals(this.oldPriceField, value) != true)) {
                    this.oldPriceField = value;
                    this.RaisePropertyChanged("oldPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string productID {
            get {
                return this.productIDField;
            }
            set {
                if ((object.ReferenceEquals(this.productIDField, value) != true)) {
                    this.productIDField = value;
                    this.RaisePropertyChanged("productID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string productName {
            get {
                return this.productNameField;
            }
            set {
                if ((object.ReferenceEquals(this.productNameField, value) != true)) {
                    this.productNameField = value;
                    this.RaisePropertyChanged("productName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string startDate {
            get {
                return this.startDateField;
            }
            set {
                if ((object.ReferenceEquals(this.startDateField, value) != true)) {
                    this.startDateField = value;
                    this.RaisePropertyChanged("startDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string storeID {
            get {
                return this.storeIDField;
            }
            set {
                if ((object.ReferenceEquals(this.storeIDField, value) != true)) {
                    this.storeIDField = value;
                    this.RaisePropertyChanged("storeID");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CStore", Namespace="http://schemas.datacontract.org/2004/07/WcfDiscount")]
    public partial class CStore : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string storeIDField;
        
        private string storeNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string storeID {
            get {
                return this.storeIDField;
            }
            set {
                if ((object.ReferenceEquals(this.storeIDField, value) != true)) {
                    this.storeIDField = value;
                    this.RaisePropertyChanged("storeID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string storeName {
            get {
                return this.storeNameField;
            }
            set {
                if ((object.ReferenceEquals(this.storeNameField, value) != true)) {
                    this.storeNameField = value;
                    this.RaisePropertyChanged("storeName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxies.IDiscountService")]
    public interface IDiscountService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDiscountService/getDiscountList", ReplyAction="http://tempuri.org/IDiscountService/getDiscountListResponse")]
        System.IAsyncResult BegingetDiscountList(string storeID, System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CProduct> EndgetDiscountList(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDiscountService/getStoreList", ReplyAction="http://tempuri.org/IDiscountService/getStoreListResponse")]
        System.IAsyncResult BegingetStoreList(System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CStore> EndgetStoreList(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDiscountService/getHash", ReplyAction="http://tempuri.org/IDiscountService/getHashResponse")]
        System.IAsyncResult BegingetHash(System.AsyncCallback callback, object asyncState);
        
        string EndgetHash(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDiscountServiceChannel : Discount.Proxies.IDiscountService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getDiscountListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getDiscountListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CProduct> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CProduct>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getStoreListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getStoreListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CStore> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CStore>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getHashCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getHashCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DiscountServiceClient : System.ServiceModel.ClientBase<Discount.Proxies.IDiscountService>, Discount.Proxies.IDiscountService {
        
        private BeginOperationDelegate onBegingetDiscountListDelegate;
        
        private EndOperationDelegate onEndgetDiscountListDelegate;
        
        private System.Threading.SendOrPostCallback ongetDiscountListCompletedDelegate;
        
        private BeginOperationDelegate onBegingetStoreListDelegate;
        
        private EndOperationDelegate onEndgetStoreListDelegate;
        
        private System.Threading.SendOrPostCallback ongetStoreListCompletedDelegate;
        
        private BeginOperationDelegate onBegingetHashDelegate;
        
        private EndOperationDelegate onEndgetHashDelegate;
        
        private System.Threading.SendOrPostCallback ongetHashCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public DiscountServiceClient() {
        }
        
        public DiscountServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DiscountServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiscountServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiscountServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<getDiscountListCompletedEventArgs> getDiscountListCompleted;
        
        public event System.EventHandler<getStoreListCompletedEventArgs> getStoreListCompleted;
        
        public event System.EventHandler<getHashCompletedEventArgs> getHashCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Discount.Proxies.IDiscountService.BegingetDiscountList(string storeID, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetDiscountList(storeID, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CProduct> Discount.Proxies.IDiscountService.EndgetDiscountList(System.IAsyncResult result) {
            return base.Channel.EndgetDiscountList(result);
        }
        
        private System.IAsyncResult OnBegingetDiscountList(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string storeID = ((string)(inValues[0]));
            return ((Discount.Proxies.IDiscountService)(this)).BegingetDiscountList(storeID, callback, asyncState);
        }
        
        private object[] OnEndgetDiscountList(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CProduct> retVal = ((Discount.Proxies.IDiscountService)(this)).EndgetDiscountList(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetDiscountListCompleted(object state) {
            if ((this.getDiscountListCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getDiscountListCompleted(this, new getDiscountListCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getDiscountListAsync(string storeID) {
            this.getDiscountListAsync(storeID, null);
        }
        
        public void getDiscountListAsync(string storeID, object userState) {
            if ((this.onBegingetDiscountListDelegate == null)) {
                this.onBegingetDiscountListDelegate = new BeginOperationDelegate(this.OnBegingetDiscountList);
            }
            if ((this.onEndgetDiscountListDelegate == null)) {
                this.onEndgetDiscountListDelegate = new EndOperationDelegate(this.OnEndgetDiscountList);
            }
            if ((this.ongetDiscountListCompletedDelegate == null)) {
                this.ongetDiscountListCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetDiscountListCompleted);
            }
            base.InvokeAsync(this.onBegingetDiscountListDelegate, new object[] {
                        storeID}, this.onEndgetDiscountListDelegate, this.ongetDiscountListCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Discount.Proxies.IDiscountService.BegingetStoreList(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetStoreList(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CStore> Discount.Proxies.IDiscountService.EndgetStoreList(System.IAsyncResult result) {
            return base.Channel.EndgetStoreList(result);
        }
        
        private System.IAsyncResult OnBegingetStoreList(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((Discount.Proxies.IDiscountService)(this)).BegingetStoreList(callback, asyncState);
        }
        
        private object[] OnEndgetStoreList(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CStore> retVal = ((Discount.Proxies.IDiscountService)(this)).EndgetStoreList(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetStoreListCompleted(object state) {
            if ((this.getStoreListCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getStoreListCompleted(this, new getStoreListCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getStoreListAsync() {
            this.getStoreListAsync(null);
        }
        
        public void getStoreListAsync(object userState) {
            if ((this.onBegingetStoreListDelegate == null)) {
                this.onBegingetStoreListDelegate = new BeginOperationDelegate(this.OnBegingetStoreList);
            }
            if ((this.onEndgetStoreListDelegate == null)) {
                this.onEndgetStoreListDelegate = new EndOperationDelegate(this.OnEndgetStoreList);
            }
            if ((this.ongetStoreListCompletedDelegate == null)) {
                this.ongetStoreListCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetStoreListCompleted);
            }
            base.InvokeAsync(this.onBegingetStoreListDelegate, null, this.onEndgetStoreListDelegate, this.ongetStoreListCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Discount.Proxies.IDiscountService.BegingetHash(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetHash(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string Discount.Proxies.IDiscountService.EndgetHash(System.IAsyncResult result) {
            return base.Channel.EndgetHash(result);
        }
        
        private System.IAsyncResult OnBegingetHash(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((Discount.Proxies.IDiscountService)(this)).BegingetHash(callback, asyncState);
        }
        
        private object[] OnEndgetHash(System.IAsyncResult result) {
            string retVal = ((Discount.Proxies.IDiscountService)(this)).EndgetHash(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetHashCompleted(object state) {
            if ((this.getHashCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getHashCompleted(this, new getHashCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getHashAsync() {
            this.getHashAsync(null);
        }
        
        public void getHashAsync(object userState) {
            if ((this.onBegingetHashDelegate == null)) {
                this.onBegingetHashDelegate = new BeginOperationDelegate(this.OnBegingetHash);
            }
            if ((this.onEndgetHashDelegate == null)) {
                this.onEndgetHashDelegate = new EndOperationDelegate(this.OnEndgetHash);
            }
            if ((this.ongetHashCompletedDelegate == null)) {
                this.ongetHashCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetHashCompleted);
            }
            base.InvokeAsync(this.onBegingetHashDelegate, null, this.onEndgetHashDelegate, this.ongetHashCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override Discount.Proxies.IDiscountService CreateChannel() {
            return new DiscountServiceClientChannel(this);
        }
        
        private class DiscountServiceClientChannel : ChannelBase<Discount.Proxies.IDiscountService>, Discount.Proxies.IDiscountService {
            
            public DiscountServiceClientChannel(System.ServiceModel.ClientBase<Discount.Proxies.IDiscountService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BegingetDiscountList(string storeID, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = storeID;
                System.IAsyncResult _result = base.BeginInvoke("getDiscountList", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CProduct> EndgetDiscountList(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CProduct> _result = ((System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CProduct>)(base.EndInvoke("getDiscountList", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BegingetStoreList(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("getStoreList", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CStore> EndgetStoreList(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CStore> _result = ((System.Collections.ObjectModel.ObservableCollection<Discount.Proxies.CStore>)(base.EndInvoke("getStoreList", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BegingetHash(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("getHash", _args, callback, asyncState);
                return _result;
            }
            
            public string EndgetHash(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("getHash", _args, result)));
                return _result;
            }
        }
    }
}
