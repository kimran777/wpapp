﻿#pragma checksum "C:\Users\kimra_000\documents\visual studio 2012\Projects\Discount\Discount\ProductPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6AF5C6BE2690B54E5DCF11CC9A54DE33"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18051
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Discount {
    
    
    public partial class ProductPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton addButton;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Primitives.Popup popupMsg;
        
        internal System.Windows.Controls.TextBlock popupMsgText;
        
        internal System.Windows.Controls.TextBlock tbStoreName;
        
        internal System.Windows.Controls.TextBlock tbID;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Image imgProductImage;
        
        internal System.Windows.Controls.TextBlock tbProductName;
        
        internal System.Windows.Controls.Button btnAdd;
        
        internal System.Windows.Controls.TextBlock tbOldPrice;
        
        internal System.Windows.Controls.TextBlock tbNewPrice;
        
        internal System.Windows.Controls.TextBlock tbDiscount;
        
        internal System.Windows.Controls.TextBlock tbStartDate;
        
        internal System.Windows.Controls.TextBlock tbEndDate;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Discount;component/ProductPage.xaml", System.UriKind.Relative));
            this.addButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("addButton")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.popupMsg = ((System.Windows.Controls.Primitives.Popup)(this.FindName("popupMsg")));
            this.popupMsgText = ((System.Windows.Controls.TextBlock)(this.FindName("popupMsgText")));
            this.tbStoreName = ((System.Windows.Controls.TextBlock)(this.FindName("tbStoreName")));
            this.tbID = ((System.Windows.Controls.TextBlock)(this.FindName("tbID")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.imgProductImage = ((System.Windows.Controls.Image)(this.FindName("imgProductImage")));
            this.tbProductName = ((System.Windows.Controls.TextBlock)(this.FindName("tbProductName")));
            this.btnAdd = ((System.Windows.Controls.Button)(this.FindName("btnAdd")));
            this.tbOldPrice = ((System.Windows.Controls.TextBlock)(this.FindName("tbOldPrice")));
            this.tbNewPrice = ((System.Windows.Controls.TextBlock)(this.FindName("tbNewPrice")));
            this.tbDiscount = ((System.Windows.Controls.TextBlock)(this.FindName("tbDiscount")));
            this.tbStartDate = ((System.Windows.Controls.TextBlock)(this.FindName("tbStartDate")));
            this.tbEndDate = ((System.Windows.Controls.TextBlock)(this.FindName("tbEndDate")));
        }
    }
}

