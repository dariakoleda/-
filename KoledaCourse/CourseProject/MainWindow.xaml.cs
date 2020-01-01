using System;
using System.Windows;
using CourseProject.Inserts;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }

        private void buttonSignIn_Click(object sender, RoutedEventArgs e)
        {
            using (Connector connector = new Connector())
            {
                try
                {
                    if (string.IsNullOrEmpty(textBoxLogin.Text.Trim()))
                        throw new Exception("Введите логин!");
                    if (passwordBox.Password.Length < 6)
                        throw new Exception("Длина пароля от 6 символов!");
                    bool is_exists = connector.SignIn(textBoxLogin.Text, passwordBox.Password);
                    if (is_exists)
                    {
                        Tables tables = new Tables();
                        tables.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
