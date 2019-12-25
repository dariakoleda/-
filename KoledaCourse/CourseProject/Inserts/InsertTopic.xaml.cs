using System;
using System.Windows;
using System.Windows.Input;

namespace CourseProject.Inserts
{
    /// <summary>
    /// Логика взаимодействия для InsertTopic.xaml
    /// </summary>
    public partial class InsertTopic : Window
    {
        private const string tableName = "Topics";

        public InsertTopic()
        {
            InitializeComponent();
            UpdateDataGrid();
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
                    string topic = textBoxName.Text.Trim();
                    if (string.IsNullOrEmpty(topic))
                        throw new Exception("Введите название темы!");
                    var mbResult = MessageBox.Show($"Вы точно хотите удалить выбранный элемент?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (mbResult == MessageBoxResult.Yes)
                    {
                        connector.InsertTopic(topic);
                    }
                }
                UpdateDataGrid();
                MessageBox.Show("Запись успешно добавлена!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = dataGridMain.SelectedItem ?? throw new Exception("Выберите запись для удаления!");
                var topicRow = dataGridMain.SelectedItem as Topic;
                var mbResult = MessageBox.Show($"Вы точно хотите удалить выбранный элемент?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mbResult == MessageBoxResult.Yes)
                {
                    using (Connector connector = new Connector())
                    {
                        connector.DeleteTopic(topicRow);
                    }
                }
                UpdateDataGrid();
                MessageBox.Show("Запись успешно удалена!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            try
            {
                using (Connector connector = new Connector())
                {
                    dataGridMain.ItemsSource = connector.GetView(tableName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
