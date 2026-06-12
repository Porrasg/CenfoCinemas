USE [cenfocinemas-db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE RET_ALL_USER_PR
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Created, UserCode, Name, Email, Password, BirthDate, Status, PhoneNumber
	FROM tblUsers;
END
GO
