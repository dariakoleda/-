CREATE DATABASE ERBook

USE ERBook

CREATE TABLE Teachers
(
	id_teacher int IDENTITY(1,1) PRIMARY KEY,
	surname varchar(30) NOT NULL,
	name varchar(30) NOT NULL,
	patronymic varchar(30)
)

CREATE TABLE Students
(
	id_student int IDENTITY(1,1) PRIMARY KEY,
	surname varchar(20) NOT NULL,
	name varchar(20) NOT NULL,
	patronymic varchar(20),
	average_mark float DEFAULT 0
)

CREATE TABLE Groups
(
	id_group int IDENTITY(1,1) PRIMARY KEY,
	group_name varchar(5) NOT NULL
)

CREATE TABLE Topics
(
	id_topic int IDENTITY(1,1) PRIMARY KEY,
	topic_name varchar(70) NOT NULL
)

CREATE TABLE Notes
(
	id_rb int IDENTITY(1,1) PRIMARY KEY,
	id_teacher int NOT NULL,
	id_student int NOT NULL,
	id_group int NOT NULL,
	id_topic int NOT NULL,
	lesson_date date NOT NULL,
	mark varchar(2),
	CONSTRAINT CH_mark CHECK ([mark] in ('1', '2', '3', '4', '5', '6', '7', '8', '9', '10') OR [mark] = N'�' OR [mark] = NULL),
	CONSTRAINT FK_Teachers_To_RB foreign key(id_teacher) REFERENCES Teachers(id_teacher),
	CONSTRAINT FK_Students_To_RB foreign key(id_student) REFERENCES Students(id_student),
	CONSTRAINT FK_Topic_To_RB foreign key(id_topic) REFERENCES Topics(id_topic),
	CONSTRAINT FK_Group_To_RB foreign key(id_group) REFERENCES Groups(id_group)
)

INSERT INTO Teachers VALUES
	(N'���������', N'������', N'�������'),
	(N'��������', N'����', N'����������'),
	(N'��������', N'�����', N'�����������'),
	(N'�������', N'�������', N'����������'),
	(N'����������', N'�������', N'�������')

INSERT INTO Students VALUES 
	(N'������', N'�������', N'���������', NULL),
	(N'������', N'�����', N'���������', NULL),
	(N'�������', N'�����', N'���������', NULL),
	(N'�����', N'�������', N'������������', NULL),
	(N'��������', N'���������', N'���������', NULL)

INSERT INTO Groups VALUES
	(N'�-710'),
	(N'�-711'),
	(N'�-712'),
	(N'�-713'),
	(N'�-714')

INSERT INTO Topics VALUES
	(N'CLR ������, ����������, �������'),
	(N'Angular 8, project structure'),
	(N'�������������� �����������'),
	(N'����������� �������������'),
	(N'������ � ������ �������������')

INSERT INTO Notes VALUES
	(1, 1, 1, 1, '2019-10-10',N'6'), 
	(2, 2, 2, 2, '2019-10-11', N'9'), 
	(3, 3, 3, 3, '2019-10-12', N'�'), 
	(4, 4, 4, 4, '2019-10-13', N'3'), 
	(5, 5, 5, 5, '2019-10-14', N'6')

GO
CREATE VIEW NotesView AS
	SELECT Teachers.surname AS [������� �������], Students.surname AS [������� ��������], Groups.group_name, Topics.topic_name, Notes.lesson_date, Notes.mark FROM Notes
	JOIN Teachers ON Notes.id_teacher = Teachers.id_teacher
	JOIN Students ON Notes.id_student = Students.id_student
	JOIN Topics ON Notes.id_topic = Topics.id_topic
	JOIN Groups ON Notes.id_group = Groups.id_group

GO
CREATE VIEW GroupsView AS
	SELECT Groups.group_name FROM Groups

GO
CREATE VIEW TopicsView AS
	SELECT Topics.topic_name FROM Topics

GO
CREATE VIEW TeachersView AS
	SELECT Teachers.surname, Teachers.name, Teachers.patronymic FROM Teachers

GO
CREATE VIEW StudentsView AS
	SELECT Students.surname, Students.name, Students.patronymic FROM Students
