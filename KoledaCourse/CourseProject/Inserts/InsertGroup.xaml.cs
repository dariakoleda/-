using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CourseProject.Inserts
{
    /// <summary>
    /// Логика взаимодействия для InsertGroup.xaml
    /// </summary>
    public partial class InsertGroup : Window
    {
        public InsertGroup()
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
                    connector.InsertGroup(textBoxName.Text);
                }
                MessageBox.Show("Запись успешно добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ". Проверьте ввод данных!");
            }
        }

    }
}
