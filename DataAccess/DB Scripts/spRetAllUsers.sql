USE [cenfocinemas-db]
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_USER_PR]    Script Date: 11/06/2026 07:04:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[RET_ALL_USER_PR]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Created, UserCode, Name, Email, Password, BirthDate, Status, PhoneNumber
	FROM tblUsers;
END
