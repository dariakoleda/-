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

        public ITable GetTableByName(string tableName)
        {
            var table = (ITable)dataClasses.GetType().GetProperty(tableName).GetValue(dataClasses, null);
            return table;
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

        public void InsertGroup(string groupName, int id_t)
        {
            Groups group = new Groups
            {
                group_name = groupName,
                id_teacher = id_t
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

        public void InsertStudent(string surname, string name, string patronymic, int id_g)
        {
            Students student = new Students
            {
                surname = surname,
                name = name,
                patronymic = patronymic,
                id_group = id_g
            };
            dataClasses.Students.InsertOnSubmit(student);
            SubmitChanges();
        }

        public void InsertTopic(string topic, DateTime? date)
        {
            Topics topics = new Topics
            {
                topic_name = topic,
                topic_date = (DateTime)date
            };
            dataClasses.Topics.InsertOnSubmit(topics);
            SubmitChanges();
        }

        public void InsertNote(int id_s, int id_topic, int mark)
        {
            Notes note = new Notes
            {
                id_student = id_s,
                id_topic = id_topic,
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
            var table = from r in dataClasses.TopicsView
                        where r.topic_name.ToLower().Contains(topicName.ToLower()) || r.topic_date.ToString().Contains(topicName.ToLower())
                        select r;
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
            var user = (from u in registrationDataContext.Users
                        where u.login == login && u.password == SHA256ToString(password)
                        select u).Single();
            if (user == null)
            {
                return false;
            }
            CurrentUser.Email = user.email;
            CurrentUser.Login = user.login;
            CurrentUser.Password = user.password;
            CurrentUser.Role = user.role;
            return true;
        }

        public void Dispose()
        {
            dataClasses.Dispose();
            registrationDataContext.Dispose();
        }

        public static string SHA256ToString(string s)
        {
            using (var alg = SHA256.Create())
                return string.Join(null, alg.ComputeHash(Encoding.UTF8.GetBytes(s)).Select(x => x.ToString("x2")));
        }
    }
}
