CREATE DATABASE Aboltus
GO
USE Aboltus
CREATE TABLE Abonents (
id INT NOT NULL PRIMARY KEY,
FIO nvarchar(50) NOT NULL,
Gender nvarchar(7) NOT NULL,
Age datetime NULL,
INN nvarchar(12) NULL,
Phone nvarchar(10) NULL,
Photo image NULL
	)