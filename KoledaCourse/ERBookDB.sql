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
	average_mark float
)

CREATE TABLE Groups
(
	id_group int IDENTITY(1,1) PRIMARY KEY,
	group_name varchar(5) NOT NULL UNIQUE
)

CREATE TABLE Topics
(
	id_topic int IDENTITY(1,1) PRIMARY KEY,
	topic_name varchar(70) NOT NULL UNIQUE
)

CREATE TABLE Notes
(
	id_rb int IDENTITY(1,1) PRIMARY KEY,
	id_teacher int NOT NULL,
	id_student int NOT NULL,
	id_group int NOT NULL,
	id_topic int NOT NULL,
	lesson_date date NOT NULL,
	mark int,
	CONSTRAINT CH_mark CHECK ([mark] BETWEEN 1 AND 10),
	CONSTRAINT FK_Teachers_To_RB foreign key(id_teacher) REFERENCES Teachers(id_teacher),
	CONSTRAINT FK_Students_To_RB foreign key(id_student) REFERENCES Students(id_student),
	CONSTRAINT FK_Topic_To_RB foreign key(id_topic) REFERENCES Topics(id_topic),
	CONSTRAINT FK_Group_To_RB foreign key(id_group) REFERENCES Groups(id_group)
)

GO
CREATE TRIGGER AvgMark_Tr On Notes AFTER INSERT, UPDATE AS
	declare @id int
	declare @avgMark float
	set @id = (SELECT inserted.id_student FROM inserted)
	set @avgMark = (SELECT AVG(Cast(Notes.mark AS float)) FROM Notes WHERE Notes.id_student = @id)
	UPDATE Students SET average_mark = @avgMark WHERE id_student = @id

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

INSERT INTO Notes VALUES (1, 1, 1, 1, '2019-10-10', N'6') 
INSERT INTO Notes VALUES (1, 2, 1, 1, '2019-10-10', N'8') 
INSERT INTO Notes VALUES (1, 3, 1, 1, '2019-10-10', N'3') 
INSERT INTO Notes VALUES (1, 4, 1, 1, '2019-10-10', N'4') 
INSERT INTO Notes VALUES (1, 5, 1, 1, '2019-10-10', N'4') 

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

GO
CREATE VIEW TopicsDates AS
	SELECT DISTINCT Topics.id_topic, Topics.topic_name, Notes.lesson_date, Groups.group_name FROM Notes
	JOIN Topics ON Notes.id_topic = Topics.id_topic
	JOIN Groups ON Notes.id_group = Groups.id_group

