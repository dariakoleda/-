using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CourseProject.Inserts
{
    /// <summary>
    /// Логика взаимодействия для InsertStudent.xaml
    /// </summary>
    public partial class InsertStudent : Window
    {
        public InsertStudent()
        {
            InitializeComponent();
        }

        private void buttonBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Connector connector = new Connector())
                {
                    connector.InsertStudent(this.textBoxSurame.Text, this.textBoxName.Text, this.textBoxPatronymic.Text);
                }
                MessageBox.Show("Запись успешно добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ". Проверьте ввод данных!");
            }
        }


        private void RusValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-Яа-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
