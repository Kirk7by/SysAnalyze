﻿#pragma checksum "..\..\..\страницы\Page3.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "478B0BE957D0D78F5D820DD79574D821"
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


namespace lb7.страницы {
    
    
    /// <summary>
    /// Page3
    /// </summary>
    public partial class Page3 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\страницы\Page3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button изменить;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\страницы\Page3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button нанять_водителя;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\страницы\Page3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button уволить;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\страницы\Page3.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Отобразить;
        
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
            System.Uri resourceLocater = new System.Uri("/lb7;component/%d1%81%d1%82%d1%80%d0%b0%d0%bd%d0%b8%d1%86%d1%8b/page3.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\страницы\Page3.xaml"
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
            this.изменить = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\страницы\Page3.xaml"
            this.изменить.Click += new System.Windows.RoutedEventHandler(this.изменить_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.нанять_водителя = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\страницы\Page3.xaml"
            this.нанять_водителя.Click += new System.Windows.RoutedEventHandler(this.нанять_водителя_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.уволить = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\страницы\Page3.xaml"
            this.уволить.Click += new System.Windows.RoutedEventHandler(this.уволить_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Отобразить = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\страницы\Page3.xaml"
            this.Отобразить.Click += new System.Windows.RoutedEventHandler(this.Отобразить_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

