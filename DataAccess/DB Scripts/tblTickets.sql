USE [cenfocinemas-db]
GO

/****** Object:  Table [dbo].[tblTickets]    Script Date: 06/06/2026 11:37:17 a. m. ******/
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


