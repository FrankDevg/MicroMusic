CREATE DATABASE [BDD_BytesMusic_Playlist];
GO

USE [BDD_BytesMusic_Playlist];
GO

/****** Object:  Table [dbo].[Tbl_Playlist_Song]    Script Date: 11/6/2023 17:58:15 ******/
SET ANSI_NULLS ON;
GO

SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE [dbo].[Tbl_Playlist_Song](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Id_Playlist] [int] NOT NULL,
	[Id_Song] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Playlist_Song] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];
GO


USE [BDD_BytesMusic_Playlist];
GO

/****** Object:  Table [dbo].[Tbl_Playlist]    Script Date: 11/6/2023 17:58:28 ******/
SET ANSI_NULLS ON;
GO

SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE [dbo].[Tbl_Playlist](
	[Id_Playlist] [int] IDENTITY(1,1) NOT NULL,
	[Id_User] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Creation_Date] [datetime2](7) NULL,
	[Type] [int] NOT NULL,
	[Photo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tbl_Playlist] PRIMARY KEY CLUSTERED 
(
	[Id_Playlist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
GO
