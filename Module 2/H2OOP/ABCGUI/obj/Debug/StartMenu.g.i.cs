﻿#pragma checksum "..\..\StartMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CAFFE00B5A4F81018B920DF1B5D9BF24EEE155AD4AF696AF11C27A17CE963E30"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ABCGUI;
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


namespace ABCGUI {
    
    
    /// <summary>
    /// StartPage
    /// </summary>
    public partial class StartPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel MarginLeft;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel MarginRight;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel BreatherName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NameLabel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtblckTrainerName;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel BreatherNameStarter;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton StarterOne;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton StarterTwo;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton StarterThree;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel BreatherStarterButton;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel BreatherButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ABCGUI;component/startmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StartMenu.xaml"
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
            this.MarginLeft = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.MarginRight = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.BreatherName = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.NameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txtblckTrainerName = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\StartMenu.xaml"
            this.txtblckTrainerName.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BreatherNameStarter = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.StarterOne = ((System.Windows.Controls.RadioButton)(target));
            
            #line 44 "..\..\StartMenu.xaml"
            this.StarterOne.Click += new System.Windows.RoutedEventHandler(this.StarterButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.StarterTwo = ((System.Windows.Controls.RadioButton)(target));
            
            #line 51 "..\..\StartMenu.xaml"
            this.StarterTwo.Click += new System.Windows.RoutedEventHandler(this.StarterButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.StarterThree = ((System.Windows.Controls.RadioButton)(target));
            
            #line 58 "..\..\StartMenu.xaml"
            this.StarterThree.Click += new System.Windows.RoutedEventHandler(this.StarterButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BreatherStarterButton = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            this.BreatherButton = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 12:
            
            #line 68 "..\..\StartMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SubmitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
