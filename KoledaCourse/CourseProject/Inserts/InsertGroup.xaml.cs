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
                        connector.InsertGroup(textBoxName.Text, (int)comboBoxTeachers.SelectedValue);
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
                comboBoxTeachers.ItemsSource = connector.dataClasses.Teachers;
                comboBoxTeachers.DisplayMemberPath = "surname";
                comboBoxTeachers.SelectedValuePath = "id_teacher";
            }
        }
    }
}
