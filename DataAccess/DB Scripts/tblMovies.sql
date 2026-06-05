USE [cenfocinemas-db]
GO

/****** Object:  Table [dbo].[tblMovies]    Script Date: 04/06/2026 10:12:38 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblMovies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Sinopsis] [nvarchar](500) NOT NULL,
	[Genre] [nvarchar](20) NOT NULL,
	[Duration] [int] NOT NULL,
	[Classification] [nvarchar](20) NOT NULL,
	[Image] [nvarchar](255) NOT NULL,
	[Status] [nvarchar](2) NOT NULL,
 CONSTRAINT [PK_tblMovies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


