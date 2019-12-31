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

        public InsertTopic()
        {
            InitializeComponent();
            dataPickerMain.SelectedDate = DateTime.Now;
            UpdateDataGrid();
            FillComboBox();
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
                    var mbResult = MessageBox.Show($"Вы точно хотите добавить данный элемент?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (mbResult == MessageBoxResult.Yes)
                    {
                        connector.InsertTopic(topic, dataPickerMain.SelectedDate);
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
                var topicRow = dataGridMain.SelectedItem as TopicsView;
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
                    dataGridMain.ItemsSource = connector.dataClasses.TopicsView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillComboBox()
        {
            try
            {
                using (Connector connector = new Connector())
                {
                    comboBoxFields.ItemsSource = connector.GetColumnsList(typeof(TopicsView));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (comboBoxFields.SelectedItem == null)
                    throw new Exception("Выберите фильтр для поиска!");
                using (Connector connector = new Connector())
                {
                    dataGridMain.ItemsSource = connector.SearchTopic(textBoxName.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
