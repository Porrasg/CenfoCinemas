USE [cenfocinemas-db]
GO

/****** Object:  Table [dbo].[tblTickets]    Script Date: 04/06/2026 10:38:55 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblTickets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Schedule] [nvarchar](20) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
	[MovieId] [int] NOT NULL,
	[Status] [nvarchar](2) NOT NULL,
 CONSTRAINT [PK_tblTickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblTickets]  WITH CHECK ADD  CONSTRAINT [FK_tblTickets_tblMovies] FOREIGN KEY([MovieId])
REFERENCES [dbo].[tblMovies] ([Id])
GO

ALTER TABLE [dbo].[tblTickets] CHECK CONSTRAINT [FK_tblTickets_tblMovies]
GO


