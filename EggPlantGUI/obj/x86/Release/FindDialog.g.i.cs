﻿#pragma checksum "..\..\..\FindDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "16C2D4FE505C599FD92A9A06E339603C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Eggplant {
    
    
    /// <summary>
    /// FindDialog
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class FindDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Eggplant.FindDialog _findDialog;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid _topGrid;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _findNext;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _replace;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _replaceAll;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _findWhat;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label _replaceLabel;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _replaceWith;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox _matchCase;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox _directionGroupBox;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton _findDown;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\FindDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton _findUp;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/EggPlantGUI;component/finddialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\FindDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this._findDialog = ((Eggplant.FindDialog)(target));
            
            #line 17 "..\..\..\FindDialog.xaml"
            this._findDialog.Activated += new System.EventHandler(this.OnActivated);
            
            #line default
            #line hidden
            return;
            case 2:
            this._topGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this._findNext = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\FindDialog.xaml"
            this._findNext.Click += new System.Windows.RoutedEventHandler(this.FindNextClicked);
            
            #line default
            #line hidden
            return;
            case 4:
            this._replace = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\FindDialog.xaml"
            this._replace.Click += new System.Windows.RoutedEventHandler(this.ReplaceClicked);
            
            #line default
            #line hidden
            return;
            case 5:
            this._replaceAll = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\FindDialog.xaml"
            this._replaceAll.Click += new System.Windows.RoutedEventHandler(this.ReplaceAllClicked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 75 "..\..\..\FindDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelClicked);
            
            #line default
            #line hidden
            return;
            case 7:
            this._findWhat = ((System.Windows.Controls.TextBox)(target));
            
            #line 114 "..\..\..\FindDialog.xaml"
            this._findWhat.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FindTextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this._replaceLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this._replaceWith = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this._matchCase = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            this._directionGroupBox = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 12:
            this._findDown = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 13:
            this._findUp = ((System.Windows.Controls.RadioButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
