﻿#pragma checksum "C:\Users\kimra_000\documents\visual studio 2012\Projects\Discount\Discount\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C0AFD38F884134CC8216365B99A6CAF1"
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
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton settingsButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton updateListButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton searchButton;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.ProgressBar progress;
        
        internal System.Windows.Controls.ListBox lbStores;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Discount;component/MainPage.xaml", System.UriKind.Relative));
            this.settingsButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("settingsButton")));
            this.updateListButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("updateListButton")));
            this.searchButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("searchButton")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.progress = ((System.Windows.Controls.ProgressBar)(this.FindName("progress")));
            this.lbStores = ((System.Windows.Controls.ListBox)(this.FindName("lbStores")));
        }
    }
}
