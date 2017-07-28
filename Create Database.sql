-- CREATE SCHEMA therapy;
USE MASTER

-- DROP DATABASE IF IT EXISTS
IF EXISTS (SELECT * FROM SYSDATABASES WHERE NAME = 'Therapy')
	DROP DATABASE Therapy

CREATE DATABASE Therapy
ON PRIMARY 
(NAME = N'Therapy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS1\MSSQL\DATA\Therapy.mdf', SIZE = 4096KB , FILEGROWTH = 1024KB)
 LOG ON 
( NAME = N'Therapy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS1\MSSQL\DATA\Therapy_log.ldf' , SIZE = 1024KB , FILEGROWTH = 10%)


USE Therapy
GO

-- Zach Scovill
-- CREATE Input_Type TABLE
CREATE TABLE [Input_Type] (
	[Type] INT NOT NULL,
	Input_Type_Desc VARCHAR (50) NOT NULL,
	Active BIT

	PRIMARY KEY ([Type])
)

--Zach Scovill
-- CREATE Questions TABLE
CREATE TABLE [Questions] (
	Question_ID INT IDENTITY (1,1) NOT NULL,
	Question VARCHAR (50),
    [Type] INT NOT NULL,
	Input_Option VARCHAR (50) NOT NULL,
	Active BIT

	PRIMARY KEY (Question_ID)
	CONSTRAINT FK_Input_Type_Type FOREIGN KEY ([Type])     
    REFERENCES Input_Type ([Type])     
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)


-- Zach Scovill
-- CREATE Assignment TABLE
CREATE TABLE Assignment (
	Assignment_ID INT IDENTITY (1,1) NOT NULL,
	Assignment_Desc VARCHAR (100),
	Active BIT

	PRIMARY KEY (Assignment_ID)
)

-- Zach Scovill
-- CREATE Form_Template TABLE
CREATE TABLE Form_Template (
	Form_ID INT IDENTITY (1,1) NOT NULL,
	Form_Desc VARCHAR (50),
	Question_ID INT,
	Assignment_ID INT,
	Active BIT

	PRIMARY KEY (Form_ID)
	CONSTRAINT FK_Questions_Question_ID FOREIGN KEY (Question_ID)
	REFERENCES Questions (Question_ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE

)

ALTER TABLE Form_Template
ADD CONSTRAINT FK_Assignment_Assignment_ID FOREIGN KEY (Assignment_ID)
	REFERENCES Assignment (Assignment_ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE

GO

-- Zach Scovill
-- CREATE Patinet TABLE
CREATE TABLE Patient (
  Patient_Id INT IDENTITY (1, 1) NOT NULL,
  First_Name VARCHAR(30) NOT NULL,
  Last_Name VARCHAR(30) NOT NULL,
  Middle_Name VARCHAR(255),
  Date_Of_Birth DATE NOT NULL,
  Gender VARCHAR(1),
  Phone_Number VARCHAR(20),
  Condition VARCHAR (100),
  [Description] VARCHAR (100)

  PRIMARY KEY (Patient_Id)

)

-- Zach Scovill
-- CREATE Medical_History TABLE
CREATE TABLE Medical_History (
	Medical_ID INT IDENTITY (1,1) NOT NULL,
	Patient_ID INT NOT NULL,
	DESCRIPTION VARCHAR(100),
	DATE_TIME DATE

	PRIMARY KEY (Medical_ID)
	CONSTRAINT FK_Patient_Patinet_ID FOREIGN KEY (Patient_ID)
	REFERENCES Patient (Patient_ID)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)


-- Zach Scovill
-- CREATE User TABLE
CREATE TABLE [User] (
	User_Name VARCHAR (50) NOT NULL,
	User_ID INT IDENTITY (1,1) NOT NULL,
	First_Name VARCHAR (30) NOT NULL,
	Last_Name VARCHAR (30) NOT NULL,
	Password VARCHAR (50) NOT NULL,
	Admin BIT,
	Password_Reset BIT,
	Email VARCHAR (50),
	Course_Number VARCHAR (20),
	Active BIT

	PRIMARY KEY (User_ID)
)


-- Zach Scovill
-- CREATE Form_Assignment TABLE
CREATE TABLE Form_Assignment (
	Form_Assingment_ID INT IDENTITY (1,1) NOT NULL,
	User_ID INT NOT NULL,
	Form_ID INT NOT NULL,
	Question_ID INT NOT NULL,
	Patient_ID INT NOT NULL,
	Answer VARCHAR (50),
	Date_Time TIMESTAMP,
	ACTIVE BIT
	
	PRIMARY KEY (Form_Assingment_ID)
	CONSTRAINT FK_User_User_ID FOREIGN KEY (User_ID)
	REFERENCES [User] (User_ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE

)

ALTER TABLE Form_Assignment
ADD CONSTRAINT FK_Form_ID FOREIGN KEY (Form_ID)
	REFERENCES Form_Template (Form_ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
CONSTRAINT FK_Question_ID FOREIGN KEY (Question_ID)
	REFERENCES Questions (Question_ID),
CONSTRAINT FK_Patient_ID FOREIGN KEY (Patient_ID)
	REFERENCES Patient (Patient_ID)



-- POPULATE DATA
--------------------------------------------------------------
--------------------------------------------------------------


USE Therapy
GO


-- INSERT INTO User
	-- User_Name : admin
	-- Password : password

INSERT INTO [User]
( User_Name, First_Name, Last_Name, Password, Admin, Password_Reset, Active, Email, Course_Number )
VALUES
( 'admin', 'admin', 'System', 'password', 1, 0, 1, 'admin@.com', '123' )


	-- User_Name : nonadmin
	-- Password : password

INSERT INTO [User]
( User_Name, First_Name, Last_Name, Password, Admin, Password_Reset, Active, Email, Course_Number )
VALUES
( 'nonadmin', 'admin', 'System', 'password', 0, 0, 1, 'nonadmin@.com', '123' )



---------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------


-- CREATE admin user account for accessing database

	--User Name : admin
	--Password : password
USE [master]
GO
CREATE LOGIN [admin] WITH PASSWORD=N'password' MUST_CHANGE, DEFAULT_DATABASE=[master], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [admin]
GO

USE [Therapy]
GO
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[db_accessadmin]
GO
USE [Therapy]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [admin]
GO
USE [Therapy]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [admin]
GO
USE [Therapy]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
USE [Therapy]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [admin]
GO
