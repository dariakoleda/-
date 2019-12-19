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
        private Connector connector = new Connector();
        private const string tableName = "Topics";

        public InsertTopic()
        {
            InitializeComponent();
            try
            {
                dataGridMain.ItemsSource = connector.GetDataTable(tableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                Connector connector = new Connector();
                string topic = textBoxName.Text.Trim();
                if (string.IsNullOrEmpty(topic))
                    throw new Exception("Введите название темы!");
                connector.InsertTopic(textBoxName.Text);
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
                connector.Delete(1);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
