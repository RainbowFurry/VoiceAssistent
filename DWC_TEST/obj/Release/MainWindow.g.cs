﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "30A205EA56E5DFAAEBD21D7FDB55289DD5EF901BA49BB18B2FD3EED97CB7F02A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using DWC_TEST;
using DarkWolfCraftSys.ui;
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


namespace DWC_TEST {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TEST;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser DWC_TEST_BROWSER;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TESTBUTTON;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle L;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle LO;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle LOL;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel sp;
        
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
            System.Uri resourceLocater = new System.Uri("/DWC_TEST;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.TEST = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.DWC_TEST_BROWSER = ((System.Windows.Controls.WebBrowser)(target));
            return;
            case 3:
            this.TESTBUTTON = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\MainWindow.xaml"
            this.TESTBUTTON.Click += new System.Windows.RoutedEventHandler(this.TESTBUTTON_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.L = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.L.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.L_C);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LO = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 6:
            this.LOL = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 7:
            
            #line 24 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.sp_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 24 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.sp_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 24 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.sp_PreviewMouseMove);
            
            #line default
            #line hidden
            
            #line 25 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).DragEnter += new System.Windows.DragEventHandler(this.sp_DragEnter);
            
            #line default
            #line hidden
            
            #line 25 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).Drop += new System.Windows.DragEventHandler(this.sp_Drop);
            
            #line default
            #line hidden
            return;
            case 8:
            this.sp = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
