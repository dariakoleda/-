using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
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
        DataClassesDataContext dataClasses = new DataClassesDataContext(Connector.ConnectionString);
        public ITable CurrentTable;
        public InsertTopic()
        {
            InitializeComponent();
            CurrentTable = connector.GetDataTable(tableName);
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
            UpdateDataGrid();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = dataGridMain.SelectedItem ?? throw new Exception("Выберите запись для удаления!");
                var topicRow = dataGridMain.SelectedItem as Topic;
                Topic topic = (from t in dataClasses.Topics where t.id_topic == topicRow.id_topic select t).Single();
                dataClasses.Topics.DeleteOnSubmit(topic);
                dataClasses.SubmitChanges();
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
                CurrentTable = connector.GetDataTable(tableName);
                dataGridMain.ItemsSource = CurrentTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
