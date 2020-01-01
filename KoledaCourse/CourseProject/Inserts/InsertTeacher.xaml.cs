using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CourseProject.Inserts
{
    /// <summary>
    /// Логика взаимодействия для InsertTeacher.xaml
    /// </summary>
    public partial class InsertTeacher : Window
    {
        public InsertTeacher()
        {
            InitializeComponent();
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Connector connector = new Connector())
                {
                    var mbResult = MessageBox.Show($"Вы точно хотите добавить данный элемент?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (mbResult == MessageBoxResult.Yes)
                    {
                        connector.InsertTeacher(textBoxSurame.Text, textBoxName.Text, textBoxPatronymic.Text);
                    }
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
