﻿#pragma checksum "C:\Users\Jinhai Steakhouse\OneDrive\Misc. Projects\wp-apache-index-formatter\wp-apache-index-formatter\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "995CC52503705D14ACBF98656A099904"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace wp_apache_index_formatter {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock uriStartText;
        
        internal System.Windows.Controls.TextBox uriStartInput;
        
        internal System.Windows.Controls.TextBlock uriLabelText;
        
        internal System.Windows.Controls.Button uriStartSaveButton;
        
        internal System.Windows.Controls.TextBlock uriSavedSuccessText;
        
        internal System.Windows.Controls.ProgressBar loadingBar;
        
        internal System.Windows.Controls.TextBlock loadingBarText;
        
        internal System.Windows.Controls.Button testParseButton;
        
        internal Microsoft.Phone.Controls.LongListSelector indexScroller;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/wp-apache-index-formatter;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.uriStartText = ((System.Windows.Controls.TextBlock)(this.FindName("uriStartText")));
            this.uriStartInput = ((System.Windows.Controls.TextBox)(this.FindName("uriStartInput")));
            this.uriLabelText = ((System.Windows.Controls.TextBlock)(this.FindName("uriLabelText")));
            this.uriStartSaveButton = ((System.Windows.Controls.Button)(this.FindName("uriStartSaveButton")));
            this.uriSavedSuccessText = ((System.Windows.Controls.TextBlock)(this.FindName("uriSavedSuccessText")));
            this.loadingBar = ((System.Windows.Controls.ProgressBar)(this.FindName("loadingBar")));
            this.loadingBarText = ((System.Windows.Controls.TextBlock)(this.FindName("loadingBarText")));
            this.testParseButton = ((System.Windows.Controls.Button)(this.FindName("testParseButton")));
            this.indexScroller = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("indexScroller")));
        }
    }
}

