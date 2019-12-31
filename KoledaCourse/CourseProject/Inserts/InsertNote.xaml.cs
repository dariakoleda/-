using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace CourseProject.Inserts
{
    /// <summary>
    /// Логика взаимодействия для InsertERBook.xaml
    /// </summary>
    public partial class InsertNote : Window
    {
        public InsertNote()
        {
            InitializeComponent();
            FillComboBoxes();
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Connector connector = new Connector())
                {
                    connector.InsertNote(
                        Convert.ToInt32(comboBoxStudent.SelectedValue),
                        Convert.ToInt32(comboBoxDate.SelectedValue),
                        Convert.ToInt32(textBoxMark.Text)
                        );
                }
                MessageBox.Show("Запись успешно добавлена!");
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ". Проверьте ввод данных!");
                DialogResult = false;
            }
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void FillComboBoxes()
        {
            using (Connector connector = new Connector())
            {
                comboBoxDate.ItemsSource = connector.dataClasses.Topics;
                comboBoxDate.DisplayMemberPath = "topic_date";
                comboBoxDate.SelectedValuePath = "id_topic";

                comboBoxStudent.ItemsSource = connector.dataClasses.Students;
                comboBoxStudent.DisplayMemberPath = "surname";
                comboBoxStudent.SelectedValuePath = "id_student";
            }
        }
    }
}
