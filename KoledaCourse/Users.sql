CREATE DATABASE Registration

USE Registration

CREATE TABLE Users
(
	id int IDENTITY(1,1) PRIMARY KEY,
	login varchar(15) UNIQUE NOT NULL,
	password varchar(64) NOT NULL,
	email varchar(30) NOT NULL,
	role varchar(5) DEFAULT 'гость',
	CONSTRAINT CH_role CHECK ([role] IN('гость', 'админ')),
)