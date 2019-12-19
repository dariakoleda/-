using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Data;

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
            this.dataPickerMain.SelectedDate = DateTime.Now;
            FillComboBoxes();
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
                Checker checker = new Checker();
                if (checker.IsCorrectMark(textBoxMark.Text))
                {
                    Connector connector = new Connector();
                    connector.InsertIntoNotes
                        (
                        Convert.ToInt32(comboBoxTeacher.SelectedValue),
                        Convert.ToInt32(comboBoxStudent.SelectedValue),
                        Convert.ToInt32(comboBoxGroup.SelectedValue),
                        Convert.ToInt32(comboBoxTopic.SelectedValue),
                        dataPickerMain.SelectedDate,
                        textBoxMark.Text
                        );
                    MessageBox.Show("Запись успешно добавлена!");
                }
                else
                {
                    MessageBox.Show("Неверная отметка!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ". Проверьте ввод данных!");
            }
            
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void FillComboBoxes()
        {
            Connector connector = new Connector();
            var dt_teachers = connector.GetDataTable("Teachers");
            var dt_students = connector.GetDataTable("Students");
            var dt_groups = connector.GetDataTable("Groups");
            var dt_topics = connector.GetDataTable("Topics");

            comboBoxTeacher.ItemsSource = dt_teachers;
            comboBoxTeacher.DisplayMemberPath = "surname";
            comboBoxTeacher.SelectedValuePath = "id_teacher";
            
            comboBoxStudent.ItemsSource = dt_students;
            comboBoxStudent.DisplayMemberPath = "surname";
            comboBoxStudent.SelectedValuePath = "id_student";

            comboBoxGroup.ItemsSource = dt_groups;
            comboBoxGroup.DisplayMemberPath = "group_name";
            comboBoxGroup.SelectedValuePath = "id_group";

            comboBoxTopic.ItemsSource = dt_topics;
            comboBoxTopic.DisplayMemberPath = "topic_name";
            comboBoxTopic.SelectedValuePath = "id_topic";
        }
    }
}
