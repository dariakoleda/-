using System;
using System.Windows;

namespace CourseProject.Inserts
{
    /// <summary>
    /// Логика взаимодействия для Inserts.xaml
    /// </summary>
    public partial class InsertsMain : Window
    {
        public InsertsMain()
        {
            InitializeComponent();
        }

        private void buttonInsertGroup_Click(object sender, RoutedEventArgs e)
        {
            InsertGroup insertGroup = new InsertGroup();
            insertGroup.ShowDialog();
        }

        private void buttonInsertStudent_Click(object sender, RoutedEventArgs e)
        {
            InsertStudent insertStudent = new InsertStudent();
            insertStudent.ShowDialog();
        }

        private void buttonInsertTopic_Click(object sender, RoutedEventArgs e)
        {
            InsertTopic insertTopic = new InsertTopic();
            insertTopic.ShowDialog();
        }

        private void buttonInsertTeacher_Click(object sender, RoutedEventArgs e)
        {
            InsertTeacher insertTeacher = new InsertTeacher();
            insertTeacher.ShowDialog();
        }
    }
}
