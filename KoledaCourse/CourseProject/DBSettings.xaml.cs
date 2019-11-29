using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для DBSettings.xaml
    /// </summary>
    public partial class DBSettings : Window
    {
        public DBSettings()
        {
            InitializeComponent();
            this.textBoxConnectionString.Text = Connector.ConnectionString;
        }

        private void buttonConnect_Click(object sender, RoutedEventArgs e)
        {
            Connector connector = new Connector();
            try
            {
                connector.CheckConnection(textBoxConnectionString.Text);
                Connector.ConnectionString = textBoxConnectionString.Text;
                this.textBoxConnectionString.Text = Connector.ConnectionString;
                MessageBox.Show("Успешно подключено!");
                this.Close();
            }
            catch (Exception ex)
            {
                var mbResult = MessageBox.Show($"{ex.Message}. Продолжить в любом случае?", "Ошибка!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (mbResult == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }

        }
    }
}
