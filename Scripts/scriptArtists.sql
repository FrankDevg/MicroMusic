CREATE DATABASE [BDD_BytesMusic_Artist];
GO

USE [BDD_BytesMusic_Artist];
GO

/****** Object:  Table [dbo].[TBL_ARTIST]    Script Date: 11/6/2023 18:00:14 ******/
SET ANSI_NULLS ON;
GO

SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE [dbo].[TBL_ARTIST](
	[ID_ARTIST] [int] IDENTITY(1,1) NOT NULL,
	[ARTIST_NAME] [varchar](100) NOT NULL,
	[ARTIST_LASTNAME] [varchar](100) NULL,
	[ARTIST_IMAGE] [varchar](255) NULL,
	PRIMARY KEY CLUSTERED 
	(
		[ID_ARTIST] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];
GO



USE [BDD_BytesMusic_Artist];
GO

/****** Object:  Table [dbo].[TBL_PLAYER]    Script Date: 11/6/2023 18:00:11 ******/
SET ANSI_NULLS ON;
GO

SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE [dbo].[TBL_PLAYER](
	[ID_SONG] [int] NOT NULL,
	[ID_ARTIST] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	CONSTRAINT [PK_TBL_PLAYER] PRIMARY KEY CLUSTERED 
	(
		[ID_SONG] ASC,
		[ID_ARTIST] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];
GO

ALTER TABLE [dbo].[TBL_PLAYER]  WITH CHECK ADD CONSTRAINT [FK_TBL_SONG_ARTIST_TBL_ARTIST] FOREIGN KEY([ID_ARTIST])
REFERENCES [dbo].[TBL_ARTIST] ([ID_ARTIST]);
GO

ALTER TABLE [dbo].[TBL_PLAYER] CHECK CONSTRAINT [FK_TBL_SONG_ARTIST_TBL_ARTIST];
GO
