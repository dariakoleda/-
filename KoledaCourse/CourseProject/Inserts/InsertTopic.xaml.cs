using System;
using System.Windows;

namespace CourseProject.Inserts
{
    /// <summary>
    /// Логика взаимодействия для InsertTopic.xaml
    /// </summary>
    public partial class InsertTopic : Window
    {
        public InsertTopic()
        {
            InitializeComponent();
            dataPickerMain.SelectedDate = DateTime.Now;
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Connector connector = new Connector())
                {
                    string topic = textBoxName.Text.Trim();
                    if (string.IsNullOrEmpty(topic))
                        throw new Exception("Введите название темы!");
                    var mbResult = MessageBox.Show($"Вы точно хотите добавить данный элемент?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (mbResult == MessageBoxResult.Yes)
                    {
                        connector.InsertTopic(topic, dataPickerMain.SelectedDate);
                        MessageBox.Show("Запись успешно добавлена!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
