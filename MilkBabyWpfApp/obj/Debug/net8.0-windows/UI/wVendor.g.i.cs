﻿#pragma checksum "..\..\..\..\UI\wVendor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7B82D7F252A46AFA29E1F913864980CAFA4DE329"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MilkBabyWpfApp.UI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MilkBabyWpfApp.UI {
    
    
    /// <summary>
    /// wVendor
    /// </summary>
    public partial class wVendor : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 27 "..\..\..\..\UI\wVendor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtVendorId;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\UI\wVendor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtVendorName;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\UI\wVendor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtVendorAddress;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\UI\wVendor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtVendorPhone;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\UI\wVendor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtVendorEmail;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\UI\wVendor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSaveVendor;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\UI\wVendor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCancelVendor;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\UI\wVendor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdVendor;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MilkBabyWpfApp;V1.0.0.0;component/ui/wvendor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\wVendor.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtVendorId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtVendorName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtVendorAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtVendorPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtVendorEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ButtonSaveVendor = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\UI\wVendor.xaml"
            this.ButtonSaveVendor.Click += new System.Windows.RoutedEventHandler(this.ButtonSaveVendor_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonCancelVendor = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\UI\wVendor.xaml"
            this.ButtonCancelVendor.Click += new System.Windows.RoutedEventHandler(this.ButtonCancelVendor_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.grdVendor = ((System.Windows.Controls.DataGrid)(target));
            
            #line 53 "..\..\..\..\UI\wVendor.xaml"
            this.grdVendor.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.grdVendor_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 9:
            
            #line 63 "..\..\..\..\UI\wVendor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.grdVendor_ButtonDelete_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

