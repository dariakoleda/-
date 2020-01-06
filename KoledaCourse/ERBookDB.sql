CREATE DATABASE ERBook

USE ERBook

CREATE TABLE Topics
(
	id_topic int IDENTITY(1,1) PRIMARY KEY,
	topic_name varchar(70) NOT NULL,
	topic_date date NOT NULL
)

CREATE TABLE Teachers
(
	id_teacher int IDENTITY(1,1) PRIMARY KEY,
	surname varchar(30) NOT NULL,
	name varchar(30) NOT NULL,
	patronymic varchar(30)
)

CREATE TABLE Groups
(
	id_group int IDENTITY(1,1) PRIMARY KEY,
	id_teacher int NOT NULL UNIQUE,
	group_name varchar(5) NOT NULL UNIQUE,
	CONSTRAINT FK_Teachers_To_RB foreign key(id_teacher) REFERENCES Teachers(id_teacher),
)

CREATE TABLE Students
(
	id_student int IDENTITY(1,1) PRIMARY KEY,
	id_group int NOT NULL,
	surname varchar(20) NOT NULL,
	name varchar(20) NOT NULL,
	patronymic varchar(20),
	average_mark float,
	CONSTRAINT FK_Group_To_RB foreign key(id_group) REFERENCES Groups(id_group)
)

CREATE TABLE Notes
(
	id_rb int IDENTITY(1,1) PRIMARY KEY,
	id_student int NOT NULL,
	id_topic int NOT NULL,
	mark int,
	CONSTRAINT CH_mark CHECK ([mark] BETWEEN 1 AND 10),
	CONSTRAINT FK_Students_To_RB foreign key(id_student) REFERENCES Students(id_student),
	CONSTRAINT FK_Topic_To_RB foreign key(id_topic) REFERENCES Topics(id_topic)
)

GO
CREATE TRIGGER AvgMark_Tr On Notes AFTER INSERT, UPDATE AS
	declare @id int
	declare @avgMark float
	set @id = (SELECT inserted.id_student FROM inserted)
	set @avgMark = (SELECT ROUND(AVG(Cast(Notes.mark AS float)),2) FROM Notes WHERE Notes.id_student = @id)
	UPDATE Students SET average_mark = @avgMark WHERE id_student = @id

INSERT INTO Topics VALUES
	(N'CLR сборка, метаданные, ресурсы', '2019-10-10'),
	(N'Angular 8, project structure', '2019-10-11'),
	(N'Информационная архитектура', '2019-10-12'),
	(N'Архитектура взимодействия', '2019-10-13'),
	(N'Работа с целями пользователей', '2019-10-14')

INSERT INTO Teachers VALUES
	(N'Григорьев', N'Максим', N'Юрьевич'),
	(N'Суворова', N'Вера', N'Робертовна'),
	(N'Миронова', N'Ирина', N'Геннадиевна'),
	(N'Тарасов', N'Дмитрий', N'Витальевич'),
	(N'Киберскотч', N'Базилик', N'Зозович')

INSERT INTO Groups VALUES
	(1, N'т-710'),
	(2, N'т-711'),
	(3, N'т-712'),
	(4, N'т-713'),
	(5, N'т-714')

INSERT INTO Students VALUES 
	(1, N'Мишина', N'Татьяна', N'Антоновна', NULL),
	(1, N'Орлова', N'Эльза', N'Борисовна', NULL),
	(2, N'Иванова', N'Алиса', N'Андреевна', NULL),
	(2, N'Зыков', N'Валерий', N'Владимирович', NULL),
	(3, N'Овервотч', N'Баттлфилд', N'Диаблович', NULL)

INSERT INTO Notes VALUES (1, 1, 6) 
INSERT INTO Notes VALUES (2, 2, 8) 
INSERT INTO Notes VALUES (3, 3, 3) 
INSERT INTO Notes VALUES (4, 4, 4) 
INSERT INTO Notes VALUES (5, 5, 4) 

GO
CREATE VIEW NotesView AS
	SELECT Students.surname AS [Фамилия студента], Topics.topic_name, Notes.mark FROM Notes
	JOIN Students ON Notes.id_student = Students.id_student
	JOIN Topics ON Notes.id_topic = Topics.id_topic

GO
CREATE VIEW GroupsView AS
	SELECT Groups.group_name FROM Groups
	JOIN Teachers ON Groups.id_teacher = Teachers.id_teacher

GO
CREATE VIEW TopicsView AS
	SELECT DISTINCT Topics.topic_name, FORMAT(Topics.topic_date, 'dd-MM-yyyy') AS [topic_date] FROM Topics

GO
CREATE VIEW TeachersView AS
	SELECT Teachers.surname, Teachers.name, Teachers.patronymic FROM Teachers

GO
CREATE VIEW StudentsView AS
	SELECT Students.surname, Students.name, Students.patronymic, Groups.group_name FROM Students
	JOIN Groups ON Students.id_group = Groups.id_group

GO
CREATE VIEW TopicsGroupsView AS
	SELECT Groups.id_group, Topics.topic_name, Topics.topic_date FROM Groups
	JOIN Students ON Students.id_group = Groups.id_group
	JOIN Notes ON Notes.id_student = Students.id_student
	JOIN Topics ON Notes.id_topic = Topics.id_topic

GO
CREATE VIEW GroupsAvgMarksView AS
	SELECT Groups.group_name, Students.average_mark FROM Groups
	JOIN Students ON Students.id_group = Groups.id_group

GO
CREATE VIEW StudentsCountInYearView AS
	SELECT Groups.group_name, Students.surname, YEAR(Topics.topic_date) AS [Год], Topics.topic_date FROM Groups
	JOIN Students ON Students.id_group = Groups.id_group
	JOIN Notes ON Notes.id_student = Students.id_student
	JOIN Topics ON Topics.id_topic = Notes.id_topic

GO
CREATE VIEW LessonsCountInMonthView AS
	SELECT Groups.group_name, Notes.id_rb, MONTH(Topics.topic_date) AS [Месяц] FROM Notes
	JOIN Students ON Students.id_student = Notes.id_student
	JOIN Groups ON Groups.id_group = Students.id_group
	JOIN Topics ON Topics.id_topic = Notes.id_topic

SELECT * FROM LessonsCountInMonthView
