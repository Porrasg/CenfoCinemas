SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE RET_ALL_MOVIE_PR
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Created, Title, Sinopsis, Genre, Duration, Classification, Image, Status
	FROM tblMovies;
END
GO
