CREATE DATABASE Registration

USE Registration

CREATE TABLE Users
(
	id int IDENTITY(1,1) PRIMARY KEY,
	login varchar(15) UNIQUE NOT NULL,
	password varchar(64) NOT NULL,
	email varchar(30) NOT NULL,
	role nvarchar(5) DEFAULT N'гость',
	CONSTRAINT CH_role CHECK ([role] IN(N'гость', N'админ')),
)

SELECT * FROM Users
UPDATE Users SET role=N'админ' WHERE id=5