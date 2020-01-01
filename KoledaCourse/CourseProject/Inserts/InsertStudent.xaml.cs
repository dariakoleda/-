using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CourseProject.Inserts
{
    /// <summary>
    /// Логика взаимодействия для InsertStudent.xaml
    /// </summary>
    public partial class InsertStudent : Window
    {
        public InsertStudent()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Connector connector = new Connector())
                {
                    var mbResult = MessageBox.Show($"Вы точно хотите добавить данный элемент?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (mbResult == MessageBoxResult.Yes)
                    {
                        connector.InsertStudent(this.textBoxSurame.Text, this.textBoxName.Text, this.textBoxPatronymic.Text, (int)comboBoxGroups.SelectedValue);
                    }
                }
                MessageBox.Show("Запись успешно добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ". Проверьте ввод данных!");
            }
        }

        private void FillComboBox()
        {
            using (Connector connector = new Connector())
            {
                comboBoxGroups.ItemsSource = connector.dataClasses.Groups;
                comboBoxGroups.DisplayMemberPath = "group_name";
                comboBoxGroups.SelectedValuePath = "id_group";
            }
        }


        private void RusValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-Яа-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
