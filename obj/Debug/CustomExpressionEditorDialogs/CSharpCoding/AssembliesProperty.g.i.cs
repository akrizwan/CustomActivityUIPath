﻿#pragma checksum "..\..\..\..\CustomExpressionEditorDialogs\CSharpCoding\AssembliesProperty.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "262EB7E3A9B2D52DD373CB283B22FBB5162B4668"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CustomActivity.CustomExpressionEditorDialogs.CSharpCoding;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace CustomActivity {
    
    
    /// <summary>
    /// AssembliesPropertyWindow
    /// </summary>
    public partial class AssembliesPropertyWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\CustomExpressionEditorDialogs\CSharpCoding\AssembliesProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddGACAssembly;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\CustomExpressionEditorDialogs\CSharpCoding\AssembliesProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveAssembly;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\CustomExpressionEditorDialogs\CSharpCoding\AssembliesProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstAssemblies;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\CustomExpressionEditorDialogs\CSharpCoding\AssembliesProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOK;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CustomActivity;component/customexpressioneditordialogs/csharpcoding/assembliespr" +
                    "operty.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\CustomExpressionEditorDialogs\CSharpCoding\AssembliesProperty.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnAddGACAssembly = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\CustomExpressionEditorDialogs\CSharpCoding\AssembliesProperty.xaml"
            this.btnAddGACAssembly.Click += new System.Windows.RoutedEventHandler(this.btnAddGACAssembly_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnRemoveAssembly = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.lstAssemblies = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.btnOK = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\CustomExpressionEditorDialogs\CSharpCoding\AssembliesProperty.xaml"
            this.btnOK.Click += new System.Windows.RoutedEventHandler(this.btnOK_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

