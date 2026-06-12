USE [cenfocinemas-db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE RET_USER_BY_ID_PR
	@P_ID INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT Id, Created, UserCode, Name, Email, Password, BirthDate, Status, PhoneNumber
    FROM tblUsers
    WHERE Id = @P_ID;
END
GO