﻿#pragma checksum "..\..\SigningWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "37F06959E50A1A2902A522D55109C9EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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


namespace Signing {
    
    
    /// <summary>
    /// SigningWindow
    /// </summary>
    public partial class SigningWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 85 "..\..\SigningWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBox1;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\SigningWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBox2;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\SigningWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBox3;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\SigningWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtBox4;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\SigningWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtBox5;
        
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
            System.Uri resourceLocater = new System.Uri("/Signing;component/signingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SigningWindow.xaml"
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
            this.txtBox1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtBox2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 86 "..\..\SigningWindow.xaml"
            this.txtBox2.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtBox2_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtBox3 = ((System.Windows.Controls.TextBox)(target));
            
            #line 87 "..\..\SigningWindow.xaml"
            this.txtBox3.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtBox3_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtBox4 = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.txtBox5 = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            
            #line 95 "..\..\SigningWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 98 "..\..\SigningWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

