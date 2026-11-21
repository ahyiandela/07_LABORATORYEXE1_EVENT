-- ahyian1234567891011 script for SQL Server Management Studio 22
-- Matches the RegistrationWithDB C# project (ClubRegistrationQuery.cs)

-- 1. Create the database
CREATE DATABASE ahyian1234567891011;
GO

USE ahyian1234567891011;
GO

-- 2. Create the table
CREATE TABLE dbo.ClubMembers (
    ID         INT          NOT NULL PRIMARY KEY,
    StudentId  BIGINT       NOT NULL UNIQUE,
    FirstName  VARCHAR(50)  NOT NULL,
    MiddleName VARCHAR(50)  NOT NULL,
    LastName   VARCHAR(50)  NOT NULL,
    Age        INT          NOT NULL,
    Gender     VARCHAR(50)  NOT NULL,
    Program    VARCHAR(50)  NOT NULL
);
GO

-- 3. Insert rows (same as the app's INSERT; ID is entered manually)
INSERT INTO ClubMembers (ID, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program)
VALUES (1, 02000000001, 'Juan', 'Santos', 'Dela Cruz', 20, 'Male', 'BS in Information Technology');

INSERT INTO ClubMembers (ID, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program)
VALUES (2, 02000000002, 'Maria', 'Reyes', 'Garcia', 19, 'Female', 'BS in Computer Science');
GO

-- 4. View all records
SELECT * FROM ClubMembers;

-- 5. View specific columns
SELECT StudentId, FirstName, LastName, Program FROM ClubMembers;

-- 6. Update a record (same as the Update form)
UPDATE ClubMembers
SET FirstName = 'Juan Carlos',
    Age = 21
WHERE StudentId = 02000000001;

-- 7. Check the update
SELECT * FROM ClubMembers WHERE StudentId = 02000000001;
GO

-- Optional: drop commands (from the handout)
-- DROP TABLE ClubMembers;
-- DROP DATABASE ahyian1234567891011;
