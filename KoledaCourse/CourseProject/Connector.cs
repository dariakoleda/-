using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CourseProject
{
    class Connector : IDisposable
    {
        public static string ConnectionString { get; set; } = "Data Source=.\\SQLEXPRESS;Initial Catalog=ERBook;Integrated Security=True";
        public static string ConnectionStringRegistartion { get; set; } = "Data Source=.\\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True";

        public readonly DataClassesDataContext dataClasses = new DataClassesDataContext(ConnectionString);
        public readonly RegistrationDataContext registrationDataContext = new RegistrationDataContext(ConnectionStringRegistartion);

        public Connector() { }

        public void CheckConnection(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Close();
            }
        }

        public ITable GetView(string tableName)
        {
            tableName += "View";
            var table = (ITable)dataClasses.GetType().GetProperty(tableName).GetValue(dataClasses, null);
            return table;
        }

        public ITable GetTableByName(string tableName)
        {
            var table = (ITable)dataClasses.GetType().GetProperty(tableName).GetValue(dataClasses, null);
            return table;
        }

        public ITable GetTableByType(Type tableType)
        {
            var table = dataClasses.GetTable(tableType);
            return table;
        }

        public List<string> GetListOfTables()
        {
            var tableList = dataClasses.Mapping.GetTables();
            var tableNames = new List<string>();
            foreach (var table in tableList)
            {
                tableNames.Add(table.TableName.Replace("dbo.", ""));
            }
            return tableNames;
        }

        public List<string> GetColumnsList(Type tableType)
        {
            var fields = dataClasses.Mapping.MappingSource
                                  .GetModel(typeof(DataClassesDataContext))
                                  .GetMetaType(tableType)
                                  .DataMembers;
            List<string> columnNames = new List<string>();
            foreach (var field in fields)
            {
                columnNames.Add(field.MappedName);
            }
            return columnNames;
        }

        public void InsertGroup(string groupName)
        {
            Groups group = new Groups
            {
                group_name = groupName
            };
            dataClasses.Groups.InsertOnSubmit(group);
            SubmitChanges();
        }

        public void InsertTeacher(string surname, string name, string patronymic)
        {
            Teachers teacher = new Teachers
            {
                surname = surname,
                name = name,
                patronymic = patronymic
            };
            dataClasses.Teachers.InsertOnSubmit(teacher);
            SubmitChanges();
        }

        public void InsertStudent(string surname, string name, string patronymic)
        {
            Students student = new Students
            {
                surname = surname,
                name = name,
                patronymic = patronymic
            };
            dataClasses.Students.InsertOnSubmit(student);
            SubmitChanges();
        }

        public void InsertTopic(string topic)
        {
            Topics topics = new Topics
            {
                topic_name = topic
            };
            dataClasses.Topics.InsertOnSubmit(topics);
            SubmitChanges();
        }

        public void InsertNote(int id_t, int id_s, int id_g, int id_topic, DateTime dateTime, int mark)
        {
            Notes note = new Notes
            {
                id_teacher = id_t,
                id_student = id_s,
                id_group = id_g,
                id_topic = id_topic,
                lesson_date = dateTime,
                mark = mark
            };
            dataClasses.Notes.InsertOnSubmit(note);
            SubmitChanges();
        }

        private void SubmitChanges()
        {
            dataClasses.SubmitChanges();
        }

        public void DeleteTopic(TopicsView topicRow)
        {
            Topics topic = (from t in dataClasses.Topics where t.topic_name == topicRow.topic_name select t).Single();
            dataClasses.Topics.DeleteOnSubmit(topic);
            SubmitChanges();
        }

        public IQueryable<TopicsView> SearchTopic(string topicName)
        {
            var table = from r in dataClasses.TopicsView where r.topic_name.ToLower().Contains(topicName.ToLower()) select r;
            return table;
        }

        public void SignUp(string login, string password, string email)
        {
            registrationDataContext.Users.InsertOnSubmit(new Users
            {
                login = login,
                password = SHA256ToString(password),
                email = email,
                role = "гость"
            });
            registrationDataContext.SubmitChanges();
        }

        public bool SignIn(string login, string password)
        {
            var user = from u in registrationDataContext.Users
                       where u.login == login && u.password == SHA256ToString(password)
                       select u;
            int usersCount = user.Count();
            if (usersCount == 0)
            {
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            dataClasses.Dispose();
        }

        public static string SHA256ToString(string s)
        {
            using (var alg = SHA256.Create())
                return string.Join(null, alg.ComputeHash(Encoding.UTF8.GetBytes(s)).Select(x => x.ToString("x2")));
        }
    }
}
