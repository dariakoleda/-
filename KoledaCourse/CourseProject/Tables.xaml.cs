using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Globalization;
using CourseProject.Inserts;

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
                comboBoxGroup.ItemsSource = connector.dataClasses.Groups;
                comboBoxGroup.DisplayMemberPath = "group_name";
                comboBoxGroup.SelectedValuePath = "id_group";
            }
        }

        private void CreateMainDataGrid()
        {
            mainDataTable.Dispose();
            mainDataTable = new DataTable();
            mainDataTable.Columns.Add("Код");
            mainDataTable.Columns.Add("Студент");
            int year = (comboBoxYear.SelectedItem as ComboboxItem).Value;
            int month = (comboBoxMonth.SelectedItem as ComboboxItem).Value;
            for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                mainDataTable.Columns.Add(i.ToString());
            }
            mainDataTable.Columns.Add("Средняя отметка");
            dataGridMain.ItemsSource = mainDataTable.DefaultView;
            dataGridMain.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void CreateTopicsDataGrid()
        {
            topicsDataTable.Dispose();
            topicsDataTable = new DataTable();
            topicsDataTable.Columns.Add("Код");
            topicsDataTable.Columns.Add("Дата занятия");
            topicsDataTable.Columns.Add("Тема");
            dataGridTopics.ItemsSource = topicsDataTable.DefaultView;
            dataGridTopics.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void FillDataGrids()
        {
            CreateMainDataGrid();
            CreateTopicsDataGrid();
            using (Connector connector = new Connector())
            {
                int id_group = (int)comboBoxGroup.SelectedValue;
                var teacher = (from g in connector.dataClasses.Groups
                               join t in connector.dataClasses.Teachers
                               on g.id_teacher equals t.id_teacher
                               where g.id_group == id_group
                               select t).Single();
                labelTeacher.Content = teacher.surname + " " + teacher.name + " " + teacher.patronymic;

                int year = (comboBoxYear.SelectedItem as ComboboxItem).Value;
                int month = (comboBoxMonth.SelectedItem as ComboboxItem).Value;
                var students = from s in connector.dataClasses.Students
                               where s.id_group == id_group
                               select s;
                foreach (var student in students)
                {
                    DataRow row = mainDataTable.NewRow();
                    row["Код"] = student.id_student;
                    row["Студент"] = student.surname;
                    row["Средняя отметка"] = student.average_mark;
                    mainDataTable.Rows.Add(row);
                }

                foreach (DataRow row in mainDataTable.Rows)
                {
                    int id_student = Convert.ToInt32(row["Код"].ToString());
                    for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                    {
                        DateTime date = new DateTime(year: year, month: month, day: day);
                        var curentStudent = (from n in connector.dataClasses.Notes
                                             join t in connector.dataClasses.Topics
                                             on n.id_topic equals t.id_topic
                                             where t.topic_date == date && n.id_student == id_student
                                             select n).FirstOrDefault();
                        if (curentStudent == null)
                            continue;

                        int? mark = curentStudent.mark;
                        if (mark != null)
                            row[day.ToString()] = mark;
                    }
                }

                string groupName = comboBoxGroup.Text;
                var topicsDates = from t in connector.dataClasses.Topics
                                  where t.topic_date.Year == year && t.topic_date.Month == month
                                  select t;

                foreach (var topic in topicsDates)
                {
                    DataRow row = topicsDataTable.NewRow();
                    row["Дата занятия"] = topic.topic_date.ToString("dd-MMM-yy");
                    row["Тема"] = topic.topic_name;
                    row["Код"] = topic.id_topic;
                    topicsDataTable.Rows.Add(row);
                }
            }
        }

        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrids();
        }

        private void menuReports_Click(object sender, RoutedEventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            int year = (comboBoxYear.SelectedItem as ComboboxItem).Value;
            int month = (comboBoxMonth.SelectedItem as ComboboxItem).Value;

            foreach (DataRow row in mainDataTable.Rows)
            {
                int id_student = Convert.ToInt32(row["Код"].ToString());
                for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                {
                    using (Connector connector = new Connector())
                    {
                        if (string.IsNullOrEmpty(row[day.ToString()].ToString()))
                        {
                            continue;
                        }
                        DateTime date = new DateTime(year: year, month: month, day: day);
                        int mark = Convert.ToInt32(row[day.ToString()].ToString());
                        var note = (from n in connector.dataClasses.Notes
                                    join t in connector.dataClasses.Topics
                                    on n.id_topic equals t.id_topic
                                    where n.id_student == id_student && t.topic_date == date
                                    select n);
                        try
                        {
                            note.Single().mark = mark;
                            connector.dataClasses.SubmitChanges();
                        }
                        catch
                        {
                            var topic = (from t in connector.dataClasses.Topics
                                         where t.topic_date == date
                                         select t);
                            var noteInsert = (from n in connector.dataClasses.Notes
                                              where n.id_student == id_student
                                              select n).FirstOrDefault();
                            if (!topic.Any())
                            {
                                MessageBox.Show($"В базе нет темы за {date.ToString("dd-MMM-yy")}!");
                                FillDataGrids();
                                return;
                            }
                            int id_g = (int)comboBoxGroup.SelectedValue;
                            int id_s = id_student;
                            int id_topic = topic.Single().id_topic;
                            connector.dataClasses.Notes.InsertOnSubmit(new Notes
                            {
                                id_student = id_s,
                                id_topic = id_topic,
                                mark = mark
                            });
                            connector.dataClasses.SubmitChanges();
                        }
                    }
                }
            }
            FillDataGrids();
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertTopic insertTopic = new InsertTopic();
            var result = insertTopic.ShowDialog();
            if (result == true)
            {
                FillDataGrids();
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FillDataGrids();
            }
            catch
            {
            }
        }

        private void menuSettingsRoles_Click(object sender, RoutedEventArgs e)
        {
            RoleChanger roleChanger = new RoleChanger();
            roleChanger.ShowDialog();
        }

        private void menuManual_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void menuUser_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            var result = user.ShowDialog();
            if (result == true)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
