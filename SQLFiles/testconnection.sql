-- DELETE FROM Students;
-- DELETE FROM Courses;

-- -- Reset the identity columns
-- DBCC CHECKIDENT('Students', RESEED, 0);
-- DBCC CHECKIDENT('Courses', RESEED, 0);

-- -- Truncate table deletes all from the table and resets identity
-- TRUNCATE TABLE Students;
-- TRUNCATE TABLE Courses;

PRINT('This is the Students table');
SELECT *
FROM Students;

PRINT('This is the Courses table');
SELECT *
FROM Courses;

PRINT('This is the Grade table');
SELECT *
FROM Grades;

-- SELECT StudentId, LastName, DateOfBirth, FirstName, GradeId, Height, [Weight]  
-- FROM Students
-- INNER JOIN Grades
-- ON Grades.Id = Students.GradeId
-- WHERE Grades.GradeName LIKE '%A'

-- -- To list all the tables in the DB
-- SELECT DISTINCT TABLE_NAME FROM information_schema.TABLES;