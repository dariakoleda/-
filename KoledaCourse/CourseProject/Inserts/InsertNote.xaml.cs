using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace CourseProject.Inserts
{
    /// <summary>
    /// Логика взаимодействия для InsertERBook.xaml
    /// </summary>
    public partial class InsertNote : Window
    {
        public InsertNote()
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
                Checker checker = new Checker();
                if (checker.IsCorrectMark(textBoxMark.Text))
                {
                    Connector connector = new Connector();
                    connector.InsertIntoNotes
                        (
                        Convert.ToInt32(textBoxIdTeacher.Text),
                        Convert.ToInt32(textBoxIdStudent.Text),
                        Convert.ToInt32(textBoxIdGroup.Text),
                        Convert.ToInt32(textBoxIdTopic.Text),
                        dataPickerMain.SelectedDate,
                        textBoxMark.Text
                        );
                    MessageBox.Show("Запись успешно добавлена!");
                }
                else
                {
                    MessageBox.Show("Неверная отметка!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ". Проверьте ввод данных!");
            }
            
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        
    }
}
