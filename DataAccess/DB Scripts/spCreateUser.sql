USE [cenfocinemas-db]
GO
/****** Object:  StoredProcedure [dbo].[CRE_USER_PR]    Script Date: 04/06/2026 10:52:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CRE_USER_PR]
(
	-- Add the parameters for the stored procedure here
	@P_USER_CODE NVARCHAR(25),
	@P_NAME NVARCHAR(50),
	@P_EMAIL NVARCHAR(30),
	@P_PASSWORD NVARCHAR(20),
	@P_BIRTH_DATE DATETIME,
	@P_STATUS NVARCHAR(2),
	@P_PHONE_NUMBER INT
)
AS
BEGIN
	INSERT INTO tblUsers (Created, UserCode, Name, Email, Password, BirthDate, Status, PhoneNumber)
	values(GETDATE(), @P_USER_CODE, @P_NAME, @P_EMAIL, @P_PASSWORD, @P_BIRTH_DATE, @P_STATUS, @P_PHONE_NUMBER);
END
