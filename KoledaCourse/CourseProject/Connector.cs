using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Data;
using System.Collections.Generic;
using System.Windows;
using System.Data.Linq;

namespace CourseProject
{
    class Connector
    {
        public static string ConnectionString { get; set; } = "Data Source=.\\SQLEXPRESS;Initial Catalog=ERBook;Integrated Security=True";

        DataClassesDataContext dataClasses = new DataClassesDataContext(ConnectionString);

        public Connector() { }

        public void CheckConnection(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Close();
            }
        }

        public ITable GetDataTable(string tableName)
        {
            var table = (ITable)dataClasses.GetType().GetProperty(tableName).GetValue(dataClasses, null);
            return table;
        }

        public List<string> GetListTables()
        {
            var tableList = dataClasses.Mapping.GetTables();
            var tableNames = new List<string>();
            foreach (var table in tableList)
            {
                tableNames.Add(table.TableName.Replace("dbo.", ""));
            }
            return tableNames;
        }

        public void InsertIntoStudents(string surname, string name, string patronymic)
        {
            string query = $"INSERT INTO Students VALUES (N'{surname}', N'{name}', N'{patronymic}', {-1})";
            Insert(query);
        }

        public void InsertIntoTeachers(string surname, string name, string patronymic)
        {
            string query = $"INSERT INTO Teachers VALUES (N'{surname}', N'{name}', N'{patronymic}')";
            Insert(query);
        }

        public void InsertIntoNotes(int id_t, int id_s, int id_g, int id_topic, DateTime? dateTime, string mark)
        {
            string query = $"INSERT INTO Notes VALUES ({id_t}, {id_s}, {id_g}, {id_topic}, '{dateTime}', N'{mark}')";
            Insert(query);
        }

        public void InsertIntoGroups(string group)
        {
            string query = $"INSERT INTO Groups VALUES (N'{group}')";
            Insert(query);
        }

        public void InsertTopic(string topic)
        {
            Topic topics = new Topic();
            topics.topic_name = topic;
            dataClasses.Topics.InsertOnSubmit(topics);
            SubmitChanges();
        }

        private void SubmitChanges()
        {
            dataClasses.SubmitChanges();
        }

        private void Insert(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.ExecuteNonQuery();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command)) { }
                sqlConnection.Close();
            }
        }

        public void Delete(int id, string tableName)
        {
            var table = GetDataTable(tableName);

            var mbResult = MessageBox.Show($"Вы точно хотите удалить элемент с номером {id}", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);   
        }
    }
}
