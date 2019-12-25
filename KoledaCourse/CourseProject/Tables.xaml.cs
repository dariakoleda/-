using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {
        public Tables()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            List<string> tables = new List<string>();
            using (Connector connector = new Connector())
            {
                tables = connector.GetListTables();
            }
            this.comboBoxMain.ItemsSource = tables;
        }

        private void comboBoxMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tableName = (sender as ComboBox).SelectedItem as string;
            using (Connector connector = new Connector())
            {
                dataGridMain.ItemsSource = connector.GetTable(tableName);
            }
            labelTableName.Content = $"Выбрана таблица \"{tableName}\":";
        }

        private void buttonBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
