﻿#pragma checksum "..\..\..\..\UI\wOrder.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CE34FFD2A95EFDFB2652BCF7B47C8472F743F2F6"
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
    /// wOrder
    /// </summary>
    public partial class wOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 27 "..\..\..\..\UI\wOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOrderID;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\UI\wOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOrderCustomerId;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\UI\wOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpOrderDate;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\UI\wOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTotalAmount;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\UI\wOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtVoucher;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\UI\wOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSaveOrder;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\UI\wOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCancelOrder;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\UI\wOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdOrder;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MilkBabyWpfApp;V1.0.0.0;component/ui/worder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\wOrder.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtOrderID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtOrderCustomerId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dpOrderDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.txtTotalAmount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtVoucher = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ButtonSaveOrder = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\UI\wOrder.xaml"
            this.ButtonSaveOrder.Click += new System.Windows.RoutedEventHandler(this.ButtonSaveOrder_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonCancelOrder = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\UI\wOrder.xaml"
            this.ButtonCancelOrder.Click += new System.Windows.RoutedEventHandler(this.ButtonCancelOrder_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.grdOrder = ((System.Windows.Controls.DataGrid)(target));
            
            #line 51 "..\..\..\..\UI\wOrder.xaml"
            this.grdOrder.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.grdOrder_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 9:
            
            #line 61 "..\..\..\..\UI\wOrder.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.grdOrder_ButtonDelete_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

