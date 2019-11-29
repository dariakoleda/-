using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Data;
using System.Collections.Generic;
using System.Windows;

namespace CourseProject
{
    class Connector
    {
        public static string ConnectionString { get; set; } = "Data Source=.\\SQLEXPRESS;Initial Catalog=ERBook;Integrated Security=True";

        public Connector() { }

        public void CheckConnection(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Close();
            }
        }

        public DataTable GetDataTable(string tN)
        {
            string tableName = tN;
            DataTable datatable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                sqlConnection.Open();
                string query = $"SELECT * FROM {tableName}";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.ExecuteNonQuery();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                sqlConnection.Close();
                return datatable;
            }
        }

        public List<string> GetListTables()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                List<string> tables = new List<string>();
                DataTable dt = sqlConnection.GetSchema("Tables");
                foreach (DataRow row in dt.Rows)
                {
                    string tablename = (string)row[2];
                    tables.Add(tablename);
                }
                sqlConnection.Close();
                return tables;
            }
        }

        public DataTable GetComboBoxData(string tN)
        {
            string tableName = tN;
            DataTable datatable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string query = $"SELECT * FROM {tableName}";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(datatable);
                cmd.Dispose();
                sqlConnection.Close();
                return datatable;
            }
        }

        public void InsertIntoStudents( string surname, string name, string patronymic)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string query = $"INSERT INTO Students VALUES (N'{surname}', N'{name}', N'{patronymic}', {-1})";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.ExecuteNonQuery();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command)) { }
                sqlConnection.Close();

            }
        }

        public void InsertIntoTeachers(string surname, string name, string patronymic)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string query = $"INSERT INTO Teachers VALUES (N'{surname}', N'{name}', N'{patronymic}')";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.ExecuteNonQuery();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command)) { }
                sqlConnection.Close();
            }
        }

        public void InsertIntoNotes(int id_t, int id_s, int id_g, int id_topic, DateTime? dateTime, string mark)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                sqlConnection.Open();
                string query = $"INSERT INTO Notes VALUES ({id_t}, {id_s}, {id_g}, {id_topic}, '{dateTime}', N'{mark}')";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.ExecuteNonQuery();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command)) { }
                sqlConnection.Close();
            }
        }

        public void InsertIntoGroups(string group)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string query = $"INSERT INTO Groups VALUES (N'{group}')";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.ExecuteNonQuery();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command)) { }
                sqlConnection.Close();
            }
        }

        public void InsertIntoTopics(string topic)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string query = $"INSERT INTO Topics VALUES (N'{topic}')";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.ExecuteNonQuery();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command)) { }
                sqlConnection.Close();
            }
        }
    }
}
