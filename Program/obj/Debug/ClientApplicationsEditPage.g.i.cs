﻿#pragma checksum "..\..\ClientApplicationsEditPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CCBBC355B55A5071201916E0A0E224AC67A8EF84514048192F858354CED2E95C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Program;
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


namespace Program {
    
    
    /// <summary>
    /// ClientApplicationsEditPage
    /// </summary>
    public partial class ClientApplicationsEditPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\ClientApplicationsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Fio_specialistTextBlock;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\ClientApplicationsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Id_the_of_the_appealTextBlock;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\ClientApplicationsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DateTextBlock;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\ClientApplicationsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\ClientApplicationsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbFilter2;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\ClientApplicationsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbFilter3;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\ClientApplicationsEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateDatePicker;
        
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
            System.Uri resourceLocater = new System.Uri("/Program;component/clientapplicationseditpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ClientApplicationsEditPage.xaml"
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
            this.Fio_specialistTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.Id_the_of_the_appealTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.DateTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\ClientApplicationsEditPage.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButtonClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CbFilter2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.CbFilter3 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.DateDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
