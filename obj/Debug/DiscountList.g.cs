﻿#pragma checksum "C:\Users\kimra_000\documents\visual studio 2012\Projects\Discount\Discount\DiscountList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6D076169C1D1CD2640BB6AE421911188"
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
    
    
    public partial class DiscountList : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock storeTitle;
        
        internal System.Windows.Controls.TextBlock tbStoreName;
        
        internal System.Windows.Controls.ProgressBar progress;
        
        internal System.Windows.Controls.ListBox lbProducts;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Discount;component/DiscountList.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.storeTitle = ((System.Windows.Controls.TextBlock)(this.FindName("storeTitle")));
            this.tbStoreName = ((System.Windows.Controls.TextBlock)(this.FindName("tbStoreName")));
            this.progress = ((System.Windows.Controls.ProgressBar)(this.FindName("progress")));
            this.lbProducts = ((System.Windows.Controls.ListBox)(this.FindName("lbProducts")));
        }
    }
}

