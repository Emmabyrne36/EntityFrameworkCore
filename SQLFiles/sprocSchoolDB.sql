CREATE PROCEDURE [dbo].[GetStudents]
    @FirstName varchar(50)
AS
    BEGIN
        SET NOCOUNT ON;
        select * from Students where FirstName like @FirstName +'%'
    END
GO