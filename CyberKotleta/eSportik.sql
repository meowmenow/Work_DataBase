CREATE DATABASE eSportik
GO
USE eSportik

CREATE TABLE CyberAthletes (
id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
CyberFIO NVARCHAR(50) NOT NULL,
Gender NVARCHAR(7) NOT NULL,
BirthDay DATETIME NOT NULL,
CoachFIO NVARCHAR(50) NOT NULL,
Country NVARCHAR(30)  NOT NULL,
DPR NVARCHAR(30) NOT NULL,
IMPACT NVARCHAR(30) NOT NULL,
ADR NVARCHAR(30) NOT NULL,
KPR NVARCHAR(30) NOT NULL,
KAST NVARCHAR(30) NOT NULL,
Photo NVARCHAR(MAX) NULL
);

CREATE TABLE Role (
RoleID INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
RoleName nvarchar(50) NOT NULL,
);

CREATE TABLE Users (
UserID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
UserFIO nvarchar(50) NOT NULL,
UserLogin nvarchar(50) NOT NULL,
UserPassword nvarchar(50) NOT NULL,
UserRole INT FOREIGN KEY REFERENCES Role(RoleId)
ON DELETE CASCADE
ON UPDATE CASCADE
);

