#pragma checksum "..\..\..\Inserts\InsertERBook.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8665FE36FFF8279C1F7C342901C77E77D54E2925506C58D04DB506F71842DFC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseProject;
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


namespace CourseProject.Inserts
{


    /// <summary>
    /// InsertERBook
    /// </summary>
    public partial class InsertERBook : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 12 "..\..\..\Inserts\InsertERBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image buttonBack;

#line default
#line hidden


#line 15 "..\..\..\Inserts\InsertERBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dataPickerMain;

#line default
#line hidden


#line 21 "..\..\..\Inserts\InsertERBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxMark;

#line default
#line hidden


#line 24 "..\..\..\Inserts\InsertERBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxIdTeacher;

#line default
#line hidden


#line 27 "..\..\..\Inserts\InsertERBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxIdStudent;

#line default
#line hidden


#line 29 "..\..\..\Inserts\InsertERBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonInsert;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CourseProject;component/inserts/inserterbook.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Inserts\InsertERBook.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.buttonBack = ((System.Windows.Controls.Image)(target));

#line 12 "..\..\..\Inserts\InsertERBook.xaml"
                    this.buttonBack.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.buttonBack_MouseDown);

#line default
#line hidden
                    return;
                case 2:
                    this.dataPickerMain = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 3:
                    this.textBoxTopic = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.textBoxMark = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.textBoxIdTeacher = ((System.Windows.Controls.TextBox)(target));

#line 24 "..\..\..\Inserts\InsertERBook.xaml"
                    this.textBoxIdTeacher.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);

#line default
#line hidden
                    return;
                case 6:
                    this.textBoxIdStudent = ((System.Windows.Controls.TextBox)(target));

#line 27 "..\..\..\Inserts\InsertERBook.xaml"
                    this.textBoxIdStudent.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);

#line default
#line hidden
                    return;
                case 7:
                    this.buttonInsert = ((System.Windows.Controls.Button)(target));

#line 29 "..\..\..\Inserts\InsertERBook.xaml"
                    this.buttonInsert.Click += new System.Windows.RoutedEventHandler(this.buttonInsert_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox textBoxIdGroup;
        internal System.Windows.Controls.TextBox textBoxIdTopic;
    }
}

