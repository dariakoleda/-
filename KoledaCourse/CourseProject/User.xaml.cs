using System;
using System.Windows;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            labelEmail.Content = CurrentUser.Email;
            labelLogin.Content = CurrentUser.Login;
            labelRole.Content = CurrentUser.Role;
        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
