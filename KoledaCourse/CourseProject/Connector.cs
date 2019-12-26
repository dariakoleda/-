using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace CourseProject
{
    class Connector : IDisposable
    {
        public static string ConnectionString { get; set; } = "Data Source=.\\SQLEXPRESS;Initial Catalog=ERBook;Integrated Security=True";

        readonly DataClassesDataContext dataClasses = new DataClassesDataContext(ConnectionString);

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
            Group group = new Group
            {
                group_name = groupName
            };
            dataClasses.Groups.InsertOnSubmit(group);
            SubmitChanges();
        }

        public void InsertTeacher(string surname, string name, string patronymic)
        {
            Teacher teacher = new Teacher
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
            Student student = new Student
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
            Topic topics = new Topic
            {
                topic_name = topic
            };
            dataClasses.Topics.InsertOnSubmit(topics);
            SubmitChanges();
        }

        public void InsertNote(int id_t, int id_s, int id_g, int id_topic, DateTime dateTime, string mark)
        {
            Note note = new Note
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
            Topic topic = (from t in dataClasses.Topics where t.topic_name == topicRow.topic_name select t).Single();
            dataClasses.Topics.DeleteOnSubmit(topic);
            SubmitChanges();
        }

        public IQueryable<TopicsView> SearchTopic(string topicName)
        {
            var table = from r in dataClasses.TopicsView where r.topic_name.ToLower().Contains(topicName.ToLower()) select r;
            return table;
        }

        public void Dispose()
        {
            dataClasses.Dispose();
        }
    }
}
