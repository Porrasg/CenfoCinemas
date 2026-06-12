USE [cenfocinemas-db]
GO
/****** Object:  StoredProcedure [dbo].[UPD_MOVIE_PR]    Script Date: 06/06/2026 09:09:27 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPD_MOVIE_PR]
(
    @P_ID INT,
    @P_TITLE NVARCHAR(100),
	@P_SINOPSIS NVARCHAR(500),
	@P_GENRE NVARCHAR(20),
	@P_DURATION INT,
	@P_CLASSIFICATION NVARCHAR(20),
	@P_IMAGE NVARCHAR(255),
	@P_STATUS NVARCHAR(2)
)
AS
BEGIN
    UPDATE tblMovies
    SET
        Updated = GETDATE(),
        Title = @P_TITLE,
        Sinopsis = @P_SINOPSIS,
        Genre = @P_GENRE,
        Duration = @P_DURATION,
        Classification = @P_CLASSIFICATION,
        Image = @P_IMAGE,
        Status = @P_STATUS
    WHERE Id = @P_ID
END
GO