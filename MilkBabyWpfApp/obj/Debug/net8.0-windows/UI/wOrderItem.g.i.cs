﻿#pragma checksum "..\..\..\..\UI\wOrderItem.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BA1715AFA6958F11A98736B76435AE3E0EA8BE5B"
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
    /// wOrderItem
    /// </summary>
    public partial class wOrderItem : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 27 "..\..\..\..\UI\wOrderItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOrderItemId;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\UI\wOrderItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOrderId;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\UI\wOrderItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductId;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\UI\wOrderItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtQuantity;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\UI\wOrderItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrice;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\UI\wOrderItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSaveOrderItem;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\UI\wOrderItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCancelOrderItem;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\UI\wOrderItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdOrderItem;
        
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
            System.Uri resourceLocater = new System.Uri("/MilkBabyWpfApp;V1.0.0.0;component/ui/worderitem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\wOrderItem.xaml"
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
            this.txtOrderItemId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtOrderId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtProductId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtQuantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ButtonSaveOrderItem = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\UI\wOrderItem.xaml"
            this.ButtonSaveOrderItem.Click += new System.Windows.RoutedEventHandler(this.ButtonSaveOrderItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonCancelOrderItem = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\UI\wOrderItem.xaml"
            this.ButtonCancelOrderItem.Click += new System.Windows.RoutedEventHandler(this.ButtonCancelOrderItem_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.grdOrderItem = ((System.Windows.Controls.DataGrid)(target));
            
            #line 51 "..\..\..\..\UI\wOrderItem.xaml"
            this.grdOrderItem.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.grdOrderItem_MouseDoubleClick);
            
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
            
            #line 61 "..\..\..\..\UI\wOrderItem.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.grdOrderItem_ButtonDelete_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

