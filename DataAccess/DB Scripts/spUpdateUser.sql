USE [cenfocinemas-db]
GO
/****** Object:  StoredProcedure [dbo].[UPD_USER_PR]    Script Date: 06/06/2026 08:56:22 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UPD_USER_PR]
(
    @P_ID INT,
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
    UPDATE tblUsers
    SET
        Updated = GETDATE(),
        UserCode = @P_USER_CODE,
        Name = @P_NAME,
        Email = @P_EMAIL,
        Password = @P_PASSWORD,
        BirthDate = @P_BIRTH_DATE,
        Status = @P_STATUS,
        PhoneNumber = @P_PHONE_NUMBER
    WHERE Id = @P_ID
END
