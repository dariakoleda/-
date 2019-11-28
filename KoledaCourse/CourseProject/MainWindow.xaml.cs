using System.Windows;
using CourseProject.Inserts;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuSettingsDB_Click(object sender, RoutedEventArgs e)
        {
            DBSettings dBSettings = new DBSettings();
            dBSettings.Show();
        }

        private void buttonShowWindowTables_Click(object sender, RoutedEventArgs e)
        {
            Tables tables = new Tables();
            tables.Show();
            this.Close();
        }

        private void buttonShowInsertStudent_Click(object sender, RoutedEventArgs e)
        {
            InsertStudent insertStudent = new InsertStudent();
            insertStudent.Show();
            this.Close();
        }

        private void buttonShowInsertTeacher_Click(object sender, RoutedEventArgs e)
        {
            InsertTeacher insertTeacher = new InsertTeacher();
            insertTeacher.Show();
            this.Close();
        }

        private void buttonShowInsertERBook_Click(object sender, RoutedEventArgs e)
        {
            InsertNote insertERBook = new InsertNote();
            insertERBook.Show();
            this.Close();
        }

        private void buttonShowInsertTopic_Click(object sender, RoutedEventArgs e)
        {
            InsertTopic insertTopic = new InsertTopic();
            insertTopic.Show();
            this.Close();
        }

        private void buttonShowInsertGroup_Click(object sender, RoutedEventArgs e)
        {
            InsertGroup insertGroup = new InsertGroup();
            insertGroup.Show();
            this.Close();
        }
    }
}
