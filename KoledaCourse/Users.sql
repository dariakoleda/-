CREATE DATABASE Registration

USE Registration

CREATE TABLE Users
(
	id int IDENTITY(1,1) PRIMARY KEY,
	login varchar(10) UNIQUE NOT NULL,
	password varchar(30) NOT NULL,
	email varchar(30) NOT NULL,
	role varchar(30) DEFAULT 'гость',
	CONSTRAINT CH_role CHECK ([role] IN('гость', 'админ')),
)

INSERT INTO Users VALUES ('1', '1', 'email@email.com', 'админ')