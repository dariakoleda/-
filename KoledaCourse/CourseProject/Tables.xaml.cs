using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Globalization;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {

        DataTable mainDataTable = new DataTable();
        DataTable topicsDataTable = new DataTable();

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
            for (int i = 2018; i <= DateTime.Now.Year; i++)
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

        private void CreateMainDataGrid()
        {
            mainDataTable.Dispose();
            mainDataTable = new DataTable();
            mainDataTable.Columns.Add("Студент");
            int year = (comboBoxYear.SelectedItem as ComboboxItem).Value;
            int month = (comboBoxMonth.SelectedItem as ComboboxItem).Value;
            for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                mainDataTable.Columns.Add(i.ToString());
            }
            mainDataTable.Columns.Add("Средняя отметка");
            dataGridMain.ItemsSource = mainDataTable.DefaultView;
        }

        private void CreateTopicsDataGrid()
        {
            topicsDataTable.Dispose();
            topicsDataTable = new DataTable();
            topicsDataTable.Columns.Add("Дата занятия");
            topicsDataTable.Columns.Add("Тема");
            dataGridTopics.ItemsSource = topicsDataTable.DefaultView;
        }

        private void FillDataGrids()
        {
            CreateMainDataGrid();
            CreateTopicsDataGrid();
            using (Connector connector = new Connector())
            {
                int year = (comboBoxYear.SelectedItem as ComboboxItem).Value;
                int month = (comboBoxMonth.SelectedItem as ComboboxItem).Value;
                var students = from s in connector.dataClasses.Students
                               join n in connector.dataClasses.Notes
                               on s.id_student equals n.id_student
                               where n.id_group == (int)comboBoxGroup.SelectedValue && n.lesson_date.Year == year && n.lesson_date.Month == month
                               select s;
                foreach (var student in students)
                {
                    DataRow row = mainDataTable.NewRow();
                    row["Студент"] = student.surname;
                    row["Средняя отметка"] = student.average_mark;
                    for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                    {
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
                    mainDataTable.Rows.Add(row);
                }
                string groupName = comboBoxGroup.Text;
                var topicsDates = from t in connector.dataClasses.TopicsDates
                                  where t.group_name == groupName && t.lesson_date.Year == year && t.lesson_date.Month == month
                                  select t;

                foreach (var topic in topicsDates)
                {
                    DataRow row = topicsDataTable.NewRow();
                    row["Дата занятия"] = topic.lesson_date.ToString("dd-MMM-yy");
                    row["Тема"] = topic.topic_name;
                    topicsDataTable.Rows.Add(row);
                }
            }
        }

        private void buttonBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrids();
        }
    }
}
