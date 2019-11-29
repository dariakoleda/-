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
        DataClassesDataContext dataClasses = new DataClassesDataContext(
            Connector.ConnectionString);

        public Tables()
        {
            InitializeComponent();
            FillComboBox();
            if (dataClasses.DatabaseExists())
            {
                this.comboBoxMain.SelectedIndex = 0;
            }
        }

        private void FillComboBox()
        {
            Connector connector = new Connector();
            List<string> tables = connector.GetListTables();
            this.comboBoxMain.ItemsSource = tables;
        }

        private void comboBoxMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tableName = (sender as ComboBox).SelectedItem as string;
            Type tableType = Type.GetType($"CourseProject.{tableName}");
            dataGridMain.ItemsSource = dataClasses.GetTable(tableType);
            labelTableName.Content = $"Выбрана таблица \"{tableName}\":";
        }

        private void buttonUpdateDB_Click(object sender, RoutedEventArgs e)
        {
            dataClasses.SubmitChanges();
            MessageBox.Show("Таблица успешно обновлена!");
        }

        private void buttonBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
