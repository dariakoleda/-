﻿#pragma checksum "..\..\..\Inserts\InsertTopic.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "790E1758991233886106B22430AFFA41165BFF83AC5EA2B1C8876367E22BDE11"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseProject.Inserts;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace CourseProject.Inserts {
    
    
    /// <summary>
    /// InsertTopic
    /// </summary>
    public partial class InsertTopic : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Inserts\InsertTopic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image buttonBack;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Inserts\InsertTopic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Inserts\InsertTopic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dataPickerMain;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Inserts\InsertTopic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonInsert;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Inserts\InsertTopic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonReset;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Inserts\InsertTopic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDelete;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Inserts\InsertTopic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridMain;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Inserts\InsertTopic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxFields;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Inserts\InsertTopic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSearch;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseProject;component/inserts/inserttopic.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Inserts\InsertTopic.xaml"
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
            this.buttonBack = ((System.Windows.Controls.Image)(target));
            
            #line 13 "..\..\..\Inserts\InsertTopic.xaml"
            this.buttonBack.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.buttonBack_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dataPickerMain = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.buttonInsert = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Inserts\InsertTopic.xaml"
            this.buttonInsert.Click += new System.Windows.RoutedEventHandler(this.buttonInsert_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonReset = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Inserts\InsertTopic.xaml"
            this.buttonReset.Click += new System.Windows.RoutedEventHandler(this.buttonReset_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonDelete = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Inserts\InsertTopic.xaml"
            this.buttonDelete.Click += new System.Windows.RoutedEventHandler(this.buttonDelete_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dataGridMain = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.comboBoxFields = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.buttonSearch = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Inserts\InsertTopic.xaml"
            this.buttonSearch.Click += new System.Windows.RoutedEventHandler(this.buttonSearch_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

