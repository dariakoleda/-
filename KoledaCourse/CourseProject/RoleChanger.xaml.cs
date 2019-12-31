using System;
using System.Linq;
using System.Windows;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для RoleChanger.xaml
    /// </summary>
    public partial class RoleChanger : Window
    {
        public RoleChanger()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Connector connector = new Connector())
                {
                    var user = (from u in connector.registrationDataContext.Users
                                where u.id == (int)comboBoxLogins.SelectedValue
                                select u).Single();
                    if (user == null)
                    {
                        MessageBox.Show("Выберите пользователя!");
                        return;
                    }
                    if (comboBoxRoles.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите роль!");
                        return;
                    }
                    user.role = comboBoxRoles.Text.ToLower();
                    connector.registrationDataContext.SubmitChanges();
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
                    comboBoxLogins.ItemsSource = connector.registrationDataContext.Users;
                    comboBoxLogins.DisplayMemberPath = "login";
                    comboBoxLogins.SelectedValuePath = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
