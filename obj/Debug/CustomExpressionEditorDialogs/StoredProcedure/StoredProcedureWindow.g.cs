﻿#pragma checksum "..\..\..\..\CustomExpressionEditorDialogs\StoredProcedure\StoredProcedureWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EB53766454908D57C8D3515BFAC6847336ED2A32"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CustomActivity;
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
    /// StoredProcedureWindow
    /// </summary>
    public partial class StoredProcedureWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\CustomExpressionEditorDialogs\StoredProcedure\StoredProcedureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStoredProcedureName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\CustomExpressionEditorDialogs\StoredProcedure\StoredProcedureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFetchParameters;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\CustomExpressionEditorDialogs\StoredProcedure\StoredProcedureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid procedureParameterGrid;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\CustomExpressionEditorDialogs\StoredProcedure\StoredProcedureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOK;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\CustomExpressionEditorDialogs\StoredProcedure\StoredProcedureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/CustomActivity;component/customexpressioneditordialogs/storedprocedure/storedpro" +
                    "cedurewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\CustomExpressionEditorDialogs\StoredProcedure\StoredProcedureWindow.xaml"
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
            
            #line 10 "..\..\..\..\CustomExpressionEditorDialogs\StoredProcedure\StoredProcedureWindow.xaml"
            ((CustomActivity.StoredProcedureWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtStoredProcedureName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnFetchParameters = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\CustomExpressionEditorDialogs\StoredProcedure\StoredProcedureWindow.xaml"
            this.btnFetchParameters.Click += new System.Windows.RoutedEventHandler(this.btnFetchParameters_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.procedureParameterGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.btnOK = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\CustomExpressionEditorDialogs\StoredProcedure\StoredProcedureWindow.xaml"
            this.btnOK.Click += new System.Windows.RoutedEventHandler(this.btnOK_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

