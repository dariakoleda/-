﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseProject
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ERBook")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertStudents(Students instance);
    partial void UpdateStudents(Students instance);
    partial void DeleteStudents(Students instance);
    partial void InsertTopics(Topics instance);
    partial void UpdateTopics(Topics instance);
    partial void DeleteTopics(Topics instance);
    partial void InsertTeachers(Teachers instance);
    partial void UpdateTeachers(Teachers instance);
    partial void DeleteTeachers(Teachers instance);
    partial void InsertNotes(Notes instance);
    partial void UpdateNotes(Notes instance);
    partial void DeleteNotes(Notes instance);
    partial void InsertGroups(Groups instance);
    partial void UpdateGroups(Groups instance);
    partial void DeleteGroups(Groups instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::CourseProject.Properties.Settings.Default.ERBookConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Students> Students
		{
			get
			{
				return this.GetTable<Students>();
			}
		}
		
		public System.Data.Linq.Table<Topics> Topics
		{
			get
			{
				return this.GetTable<Topics>();
			}
		}
		
		public System.Data.Linq.Table<Teachers> Teachers
		{
			get
			{
				return this.GetTable<Teachers>();
			}
		}
		
		public System.Data.Linq.Table<Notes> Notes
		{
			get
			{
				return this.GetTable<Notes>();
			}
		}
		
		public System.Data.Linq.Table<Groups> Groups
		{
			get
			{
				return this.GetTable<Groups>();
			}
		}
		
		public System.Data.Linq.Table<TopicsView> TopicsView
		{
			get
			{
				return this.GetTable<TopicsView>();
			}
		}
		
		public System.Data.Linq.Table<TeachersView> TeachersView
		{
			get
			{
				return this.GetTable<TeachersView>();
			}
		}
		
		public System.Data.Linq.Table<StudentsView> StudentsView
		{
			get
			{
				return this.GetTable<StudentsView>();
			}
		}
		
		public System.Data.Linq.Table<NotesView> NotesView
		{
			get
			{
				return this.GetTable<NotesView>();
			}
		}
		
		public System.Data.Linq.Table<GroupsView> GroupsView
		{
			get
			{
				return this.GetTable<GroupsView>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Students")]
	public partial class Students : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_student;
		
		private int _id_group;
		
		private string _surname;
		
		private string _name;
		
		private string _patronymic;
		
		private System.Nullable<double> _average_mark;
		
		private EntitySet<Notes> _Notes;
		
		private EntityRef<Groups> _Groups;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_studentChanging(int value);
    partial void Onid_studentChanged();
    partial void Onid_groupChanging(int value);
    partial void Onid_groupChanged();
    partial void OnsurnameChanging(string value);
    partial void OnsurnameChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnpatronymicChanging(string value);
    partial void OnpatronymicChanged();
    partial void Onaverage_markChanging(System.Nullable<double> value);
    partial void Onaverage_markChanged();
    #endregion
		
		public Students()
		{
			this._Notes = new EntitySet<Notes>(new Action<Notes>(this.attach_Notes), new Action<Notes>(this.detach_Notes));
			this._Groups = default(EntityRef<Groups>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_student", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_student
		{
			get
			{
				return this._id_student;
			}
			set
			{
				if ((this._id_student != value))
				{
					this.Onid_studentChanging(value);
					this.SendPropertyChanging();
					this._id_student = value;
					this.SendPropertyChanged("id_student");
					this.Onid_studentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_group", DbType="Int NOT NULL")]
		public int id_group
		{
			get
			{
				return this._id_group;
			}
			set
			{
				if ((this._id_group != value))
				{
					if (this._Groups.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_groupChanging(value);
					this.SendPropertyChanging();
					this._id_group = value;
					this.SendPropertyChanged("id_group");
					this.Onid_groupChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_surname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string surname
		{
			get
			{
				return this._surname;
			}
			set
			{
				if ((this._surname != value))
				{
					this.OnsurnameChanging(value);
					this.SendPropertyChanging();
					this._surname = value;
					this.SendPropertyChanged("surname");
					this.OnsurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_patronymic", DbType="VarChar(20)")]
		public string patronymic
		{
			get
			{
				return this._patronymic;
			}
			set
			{
				if ((this._patronymic != value))
				{
					this.OnpatronymicChanging(value);
					this.SendPropertyChanging();
					this._patronymic = value;
					this.SendPropertyChanged("patronymic");
					this.OnpatronymicChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_average_mark", DbType="Float")]
		public System.Nullable<double> average_mark
		{
			get
			{
				return this._average_mark;
			}
			set
			{
				if ((this._average_mark != value))
				{
					this.Onaverage_markChanging(value);
					this.SendPropertyChanging();
					this._average_mark = value;
					this.SendPropertyChanged("average_mark");
					this.Onaverage_markChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Students_Notes", Storage="_Notes", ThisKey="id_student", OtherKey="id_student")]
		public EntitySet<Notes> Notes
		{
			get
			{
				return this._Notes;
			}
			set
			{
				this._Notes.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Groups_Students", Storage="_Groups", ThisKey="id_group", OtherKey="id_group", IsForeignKey=true)]
		public Groups Groups
		{
			get
			{
				return this._Groups.Entity;
			}
			set
			{
				Groups previousValue = this._Groups.Entity;
				if (((previousValue != value) 
							|| (this._Groups.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Groups.Entity = null;
						previousValue.Students.Remove(this);
					}
					this._Groups.Entity = value;
					if ((value != null))
					{
						value.Students.Add(this);
						this._id_group = value.id_group;
					}
					else
					{
						this._id_group = default(int);
					}
					this.SendPropertyChanged("Groups");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Notes(Notes entity)
		{
			this.SendPropertyChanging();
			entity.Students = this;
		}
		
		private void detach_Notes(Notes entity)
		{
			this.SendPropertyChanging();
			entity.Students = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Topics")]
	public partial class Topics : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_topic;
		
		private string _topic_name;
		
		private System.DateTime _topic_date;
		
		private EntitySet<Notes> _Notes;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_topicChanging(int value);
    partial void Onid_topicChanged();
    partial void Ontopic_nameChanging(string value);
    partial void Ontopic_nameChanged();
    partial void Ontopic_dateChanging(System.DateTime value);
    partial void Ontopic_dateChanged();
    #endregion
		
		public Topics()
		{
			this._Notes = new EntitySet<Notes>(new Action<Notes>(this.attach_Notes), new Action<Notes>(this.detach_Notes));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_topic", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_topic
		{
			get
			{
				return this._id_topic;
			}
			set
			{
				if ((this._id_topic != value))
				{
					this.Onid_topicChanging(value);
					this.SendPropertyChanging();
					this._id_topic = value;
					this.SendPropertyChanged("id_topic");
					this.Onid_topicChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_topic_name", DbType="VarChar(70) NOT NULL", CanBeNull=false)]
		public string topic_name
		{
			get
			{
				return this._topic_name;
			}
			set
			{
				if ((this._topic_name != value))
				{
					this.Ontopic_nameChanging(value);
					this.SendPropertyChanging();
					this._topic_name = value;
					this.SendPropertyChanged("topic_name");
					this.Ontopic_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_topic_date", DbType="Date NOT NULL")]
		public System.DateTime topic_date
		{
			get
			{
				return this._topic_date;
			}
			set
			{
				if ((this._topic_date != value))
				{
					this.Ontopic_dateChanging(value);
					this.SendPropertyChanging();
					this._topic_date = value;
					this.SendPropertyChanged("topic_date");
					this.Ontopic_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Topics_Notes", Storage="_Notes", ThisKey="id_topic", OtherKey="id_topic")]
		public EntitySet<Notes> Notes
		{
			get
			{
				return this._Notes;
			}
			set
			{
				this._Notes.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Notes(Notes entity)
		{
			this.SendPropertyChanging();
			entity.Topics = this;
		}
		
		private void detach_Notes(Notes entity)
		{
			this.SendPropertyChanging();
			entity.Topics = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Teachers")]
	public partial class Teachers : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_teacher;
		
		private string _surname;
		
		private string _name;
		
		private string _patronymic;
		
		private EntitySet<Groups> _Groups;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_teacherChanging(int value);
    partial void Onid_teacherChanged();
    partial void OnsurnameChanging(string value);
    partial void OnsurnameChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnpatronymicChanging(string value);
    partial void OnpatronymicChanged();
    #endregion
		
		public Teachers()
		{
			this._Groups = new EntitySet<Groups>(new Action<Groups>(this.attach_Groups), new Action<Groups>(this.detach_Groups));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_teacher", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_teacher
		{
			get
			{
				return this._id_teacher;
			}
			set
			{
				if ((this._id_teacher != value))
				{
					this.Onid_teacherChanging(value);
					this.SendPropertyChanging();
					this._id_teacher = value;
					this.SendPropertyChanged("id_teacher");
					this.Onid_teacherChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_surname", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string surname
		{
			get
			{
				return this._surname;
			}
			set
			{
				if ((this._surname != value))
				{
					this.OnsurnameChanging(value);
					this.SendPropertyChanging();
					this._surname = value;
					this.SendPropertyChanged("surname");
					this.OnsurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_patronymic", DbType="VarChar(30)")]
		public string patronymic
		{
			get
			{
				return this._patronymic;
			}
			set
			{
				if ((this._patronymic != value))
				{
					this.OnpatronymicChanging(value);
					this.SendPropertyChanging();
					this._patronymic = value;
					this.SendPropertyChanged("patronymic");
					this.OnpatronymicChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Teachers_Groups", Storage="_Groups", ThisKey="id_teacher", OtherKey="id_teacher")]
		public EntitySet<Groups> Groups
		{
			get
			{
				return this._Groups;
			}
			set
			{
				this._Groups.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Groups(Groups entity)
		{
			this.SendPropertyChanging();
			entity.Teachers = this;
		}
		
		private void detach_Groups(Groups entity)
		{
			this.SendPropertyChanging();
			entity.Teachers = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Notes")]
	public partial class Notes : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_rb;
		
		private int _id_student;
		
		private int _id_topic;
		
		private System.Nullable<int> _mark;
		
		private EntityRef<Students> _Students;
		
		private EntityRef<Topics> _Topics;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_rbChanging(int value);
    partial void Onid_rbChanged();
    partial void Onid_studentChanging(int value);
    partial void Onid_studentChanged();
    partial void Onid_topicChanging(int value);
    partial void Onid_topicChanged();
    partial void OnmarkChanging(System.Nullable<int> value);
    partial void OnmarkChanged();
    #endregion
		
		public Notes()
		{
			this._Students = default(EntityRef<Students>);
			this._Topics = default(EntityRef<Topics>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_rb", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_rb
		{
			get
			{
				return this._id_rb;
			}
			set
			{
				if ((this._id_rb != value))
				{
					this.Onid_rbChanging(value);
					this.SendPropertyChanging();
					this._id_rb = value;
					this.SendPropertyChanged("id_rb");
					this.Onid_rbChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_student", DbType="Int NOT NULL")]
		public int id_student
		{
			get
			{
				return this._id_student;
			}
			set
			{
				if ((this._id_student != value))
				{
					if (this._Students.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_studentChanging(value);
					this.SendPropertyChanging();
					this._id_student = value;
					this.SendPropertyChanged("id_student");
					this.Onid_studentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_topic", DbType="Int NOT NULL")]
		public int id_topic
		{
			get
			{
				return this._id_topic;
			}
			set
			{
				if ((this._id_topic != value))
				{
					if (this._Topics.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_topicChanging(value);
					this.SendPropertyChanging();
					this._id_topic = value;
					this.SendPropertyChanged("id_topic");
					this.Onid_topicChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mark", DbType="Int")]
		public System.Nullable<int> mark
		{
			get
			{
				return this._mark;
			}
			set
			{
				if ((this._mark != value))
				{
					this.OnmarkChanging(value);
					this.SendPropertyChanging();
					this._mark = value;
					this.SendPropertyChanged("mark");
					this.OnmarkChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Students_Notes", Storage="_Students", ThisKey="id_student", OtherKey="id_student", IsForeignKey=true)]
		public Students Students
		{
			get
			{
				return this._Students.Entity;
			}
			set
			{
				Students previousValue = this._Students.Entity;
				if (((previousValue != value) 
							|| (this._Students.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Students.Entity = null;
						previousValue.Notes.Remove(this);
					}
					this._Students.Entity = value;
					if ((value != null))
					{
						value.Notes.Add(this);
						this._id_student = value.id_student;
					}
					else
					{
						this._id_student = default(int);
					}
					this.SendPropertyChanged("Students");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Topics_Notes", Storage="_Topics", ThisKey="id_topic", OtherKey="id_topic", IsForeignKey=true)]
		public Topics Topics
		{
			get
			{
				return this._Topics.Entity;
			}
			set
			{
				Topics previousValue = this._Topics.Entity;
				if (((previousValue != value) 
							|| (this._Topics.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Topics.Entity = null;
						previousValue.Notes.Remove(this);
					}
					this._Topics.Entity = value;
					if ((value != null))
					{
						value.Notes.Add(this);
						this._id_topic = value.id_topic;
					}
					else
					{
						this._id_topic = default(int);
					}
					this.SendPropertyChanged("Topics");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Groups")]
	public partial class Groups : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_group;
		
		private int _id_teacher;
		
		private string _group_name;
		
		private EntitySet<Students> _Students;
		
		private EntityRef<Teachers> _Teachers;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_groupChanging(int value);
    partial void Onid_groupChanged();
    partial void Onid_teacherChanging(int value);
    partial void Onid_teacherChanged();
    partial void Ongroup_nameChanging(string value);
    partial void Ongroup_nameChanged();
    #endregion
		
		public Groups()
		{
			this._Students = new EntitySet<Students>(new Action<Students>(this.attach_Students), new Action<Students>(this.detach_Students));
			this._Teachers = default(EntityRef<Teachers>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_group", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_group
		{
			get
			{
				return this._id_group;
			}
			set
			{
				if ((this._id_group != value))
				{
					this.Onid_groupChanging(value);
					this.SendPropertyChanging();
					this._id_group = value;
					this.SendPropertyChanged("id_group");
					this.Onid_groupChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_teacher", DbType="Int NOT NULL")]
		public int id_teacher
		{
			get
			{
				return this._id_teacher;
			}
			set
			{
				if ((this._id_teacher != value))
				{
					if (this._Teachers.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_teacherChanging(value);
					this.SendPropertyChanging();
					this._id_teacher = value;
					this.SendPropertyChanged("id_teacher");
					this.Onid_teacherChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_group_name", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string group_name
		{
			get
			{
				return this._group_name;
			}
			set
			{
				if ((this._group_name != value))
				{
					this.Ongroup_nameChanging(value);
					this.SendPropertyChanging();
					this._group_name = value;
					this.SendPropertyChanged("group_name");
					this.Ongroup_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Groups_Students", Storage="_Students", ThisKey="id_group", OtherKey="id_group")]
		public EntitySet<Students> Students
		{
			get
			{
				return this._Students;
			}
			set
			{
				this._Students.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Teachers_Groups", Storage="_Teachers", ThisKey="id_teacher", OtherKey="id_teacher", IsForeignKey=true)]
		public Teachers Teachers
		{
			get
			{
				return this._Teachers.Entity;
			}
			set
			{
				Teachers previousValue = this._Teachers.Entity;
				if (((previousValue != value) 
							|| (this._Teachers.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Teachers.Entity = null;
						previousValue.Groups.Remove(this);
					}
					this._Teachers.Entity = value;
					if ((value != null))
					{
						value.Groups.Add(this);
						this._id_teacher = value.id_teacher;
					}
					else
					{
						this._id_teacher = default(int);
					}
					this.SendPropertyChanged("Teachers");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Students(Students entity)
		{
			this.SendPropertyChanging();
			entity.Groups = this;
		}
		
		private void detach_Students(Students entity)
		{
			this.SendPropertyChanging();
			entity.Groups = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TopicsView")]
	public partial class TopicsView
	{
		
		private string _topic_name;
		
		private System.DateTime _topic_date;
		
		public TopicsView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_topic_name", DbType="VarChar(70) NOT NULL", CanBeNull=false)]
		public string topic_name
		{
			get
			{
				return this._topic_name;
			}
			set
			{
				if ((this._topic_name != value))
				{
					this._topic_name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_topic_date", DbType="Date NOT NULL")]
		public System.DateTime topic_date
		{
			get
			{
				return this._topic_date;
			}
			set
			{
				if ((this._topic_date != value))
				{
					this._topic_date = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TeachersView")]
	public partial class TeachersView
	{
		
		private string _surname;
		
		private string _name;
		
		private string _patronymic;
		
		public TeachersView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_surname", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string surname
		{
			get
			{
				return this._surname;
			}
			set
			{
				if ((this._surname != value))
				{
					this._surname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_patronymic", DbType="VarChar(30)")]
		public string patronymic
		{
			get
			{
				return this._patronymic;
			}
			set
			{
				if ((this._patronymic != value))
				{
					this._patronymic = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.StudentsView")]
	public partial class StudentsView
	{
		
		private string _surname;
		
		private string _name;
		
		private string _patronymic;
		
		private string _group_name;
		
		public StudentsView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_surname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string surname
		{
			get
			{
				return this._surname;
			}
			set
			{
				if ((this._surname != value))
				{
					this._surname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_patronymic", DbType="VarChar(20)")]
		public string patronymic
		{
			get
			{
				return this._patronymic;
			}
			set
			{
				if ((this._patronymic != value))
				{
					this._patronymic = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_group_name", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string group_name
		{
			get
			{
				return this._group_name;
			}
			set
			{
				if ((this._group_name != value))
				{
					this._group_name = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NotesView")]
	public partial class NotesView
	{
		
		private string _Фамилия_студента;
		
		private string _topic_name;
		
		private System.Nullable<int> _mark;
		
		public NotesView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Фамилия студента]", Storage="_Фамилия_студента", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Фамилия_студента
		{
			get
			{
				return this._Фамилия_студента;
			}
			set
			{
				if ((this._Фамилия_студента != value))
				{
					this._Фамилия_студента = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_topic_name", DbType="VarChar(70) NOT NULL", CanBeNull=false)]
		public string topic_name
		{
			get
			{
				return this._topic_name;
			}
			set
			{
				if ((this._topic_name != value))
				{
					this._topic_name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mark", DbType="Int")]
		public System.Nullable<int> mark
		{
			get
			{
				return this._mark;
			}
			set
			{
				if ((this._mark != value))
				{
					this._mark = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.GroupsView")]
	public partial class GroupsView
	{
		
		private string _group_name;
		
		public GroupsView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_group_name", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string group_name
		{
			get
			{
				return this._group_name;
			}
			set
			{
				if ((this._group_name != value))
				{
					this._group_name = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
