using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void buttonSignUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Connector connector = new Connector())
                {
                    if (string.IsNullOrEmpty(textBoxLogin.Text.Trim()))
                        throw new Exception("Введите логин!");
                    if (passwordBox.Password.Length < 6)
                        throw new Exception("Длина пароля от 6 символов!");
                    if (string.IsNullOrEmpty(textBoxEmail.Text.Trim()))
                        throw new Exception("Введите почтовый ящик!");
                    MailAddress mailAddress = new MailAddress(textBoxEmail.Text);
                    connector.SignUp(textBoxLogin.Text, passwordBox.Password, mailAddress.Address);
                    MessageBox.Show("Вы успешно зарегистрированы");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Такой логин уже существует!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
