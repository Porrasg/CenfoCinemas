USE [cenfocinemas-db]
GO
/****** Object:  StoredProcedure [dbo].[UPD_TICKET_PR]    Script Date: 06/06/2026 09:13:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPD_TICKET_PR]
(
    @P_ID INT,
    @P_PRICE DECIMAL(10,2),
	@P_SCHEDULE NVARCHAR(20),
	@P_DATE DATETIME,
	@P_TYPE NVARCHAR(20),
	@P_MOVIE_ID INT,
	@P_STATUS NVARCHAR(2)
)
AS
BEGIN
    UPDATE tblTickets
    SET
        Updated = GETDATE(),
        Price = @P_PRICE,
        Schedule = @P_SCHEDULE,
        Date = @P_DATE,
        Type = @P_TYPE,
        MovieId = @P_MOVIE_ID,
        Status = @P_STATUS
    WHERE Id = @P_ID
END
GO