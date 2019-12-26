using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Linq;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {

        DataTable dataTable = new DataTable();

        class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public Tables()
        {
            InitializeComponent();
            FillComboBoxes();
        }

        private void FillComboBoxes()
        {
            List<string> months = new List<string>
            {
                "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
            };
            int monthNum = 1;
            foreach (var month in months)
            {
                ComboboxItem item = new ComboboxItem()
                {
                    Text = month,
                    Value = monthNum
                };
                monthNum++;
                comboBoxMonth.Items.Add(item);
            }
            for (int i = 2017; i <= DateTime.Now.Year; i++)
            {
                ComboboxItem item = new ComboboxItem()
                {
                    Text = i.ToString(),
                    Value = i
                };
                comboBoxYear.Items.Add(item);
            }
            using (Connector connector = new Connector())
            {
                var dt_groups = connector.GetTableByType(typeof(Groups));
                comboBoxGroup.ItemsSource = dt_groups;
                comboBoxGroup.DisplayMemberPath = "group_name";
                comboBoxGroup.SelectedValuePath = "id_group";
            }
        }

        private void CreateDataGrid()
        {
            dataTable.Dispose();
            dataTable = new DataTable();
            dataTable.Columns.Add("Студент");
            for (int i = 1; i <= 31; i++)
            {
                dataTable.Columns.Add(i.ToString());
            }
            dataTable.Columns.Add("Средняя отметка");
            dataGridMain.ItemsSource = dataTable.DefaultView;
        }

        private void FillMainDataGrid()
        {
            CreateDataGrid();
            using (Connector connector = new Connector())
            {
                var students = from s in connector.dataClasses.Students
                               join n in connector.dataClasses.Notes
                               on s.id_student equals n.id_student
                               where n.id_group == (int)comboBoxGroup.SelectedValue
                               select s;
                foreach (var student in students)
                {
                    DataRow row = dataTable.NewRow();
                    row["Студент"] = student.surname;
                    row["Средняя отметка"] = student.average_mark;
                    for (int day = 1; day <= 31; day++)
                    {
                        int year = (comboBoxYear.SelectedItem as ComboboxItem).Value;
                        int month = (comboBoxMonth.SelectedItem as ComboboxItem).Value;
                        DateTime date = new DateTime(year: year, month: month, day: day);
                        var curentStudent = (from n in connector.dataClasses.Notes
                                             join s in connector.dataClasses.Students
                                             on n.id_student equals s.id_student
                                             where n.lesson_date == date && n.id_student == student.id_student
                                             select n).FirstOrDefault();
                        if (curentStudent == null)
                            continue;

                        int? mark = curentStudent.mark;
                        if (mark != null)
                            row[day.ToString()] = mark;
                    }
                    dataTable.Rows.Add(row);
                }
            }
        }

        private void FillTopicsDataGrid()
        {

        }

        private void buttonBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            FillMainDataGrid();
        }
    }
}
