﻿#pragma checksum "..\..\..\Designers\InvokeWorkflowFromDatabaseDesigner.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11B260096B50E4F828471204A2D4F5997E694D16"
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
using System.Activities.Presentation;
using System.Activities.Presentation.Converters;
using System.Activities.Presentation.View;
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
    /// InvokeWorkflowFromDatabaseDesigner
    /// </summary>
    public partial class InvokeWorkflowFromDatabaseDesigner : System.Activities.Presentation.ActivityDesigner, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\Designers\InvokeWorkflowFromDatabaseDesigner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Activities.Presentation.View.ExpressionTextBox inputTextBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Designers\InvokeWorkflowFromDatabaseDesigner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox activityNameComboBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Designers\InvokeWorkflowFromDatabaseDesigner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Activities.Presentation.View.ExpressionTextBox outputTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/CustomActivity;component/designers/invokeworkflowfromdatabasedesigner.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Designers\InvokeWorkflowFromDatabaseDesigner.xaml"
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
            
            #line 8 "..\..\..\Designers\InvokeWorkflowFromDatabaseDesigner.xaml"
            ((CustomActivity.InvokeWorkflowFromDatabaseDesigner)(target)).Loaded += new System.Windows.RoutedEventHandler(this.ActivityDesigner_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.inputTextBox = ((System.Activities.Presentation.View.ExpressionTextBox)(target));
            return;
            case 3:
            this.activityNameComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.outputTextBox = ((System.Activities.Presentation.View.ExpressionTextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

