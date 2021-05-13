USE [Studenti]
GO

/****** Object:  Table [dbo].[Materii]    Script Date: 13.05.2021 16:36:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Materii](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Denumire] [nvarchar](50) NULL,
	[NrCredite] [smallint] NULL,
	[TipExamen] [nvarchar](50) NULL,
 CONSTRAINT [PK_Materii] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Studenti](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NrMatricol] [nvarchar](50) NOT NULL,
	[Nume] [nvarchar](50) NULL,
	[Adresa] [nvarchar](100) NULL,
	[Oras] [nvarchar](50) NULL,
	[Telefon] [nvarchar](10) NULL,
	[DataNasterii] [date] NULL,
 CONSTRAINT [PK_Studenti] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Note](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDMaterie] [int] NOT NULL,
	[IDStudent] [int] NOT NULL,
	[Nota] [smallint] NULL,
	[Data] [date] NULL,
	[TipExamen] [nvarchar](50) NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Materii] FOREIGN KEY([IDMaterie])
REFERENCES [dbo].[Materii] ([ID])
GO

ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Materii]
GO

ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Studenti] FOREIGN KEY([IDStudent])
REFERENCES [dbo].[Studenti] ([ID])
GO

ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Studenti]
GO

