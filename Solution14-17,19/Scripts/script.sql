USE [master]
GO


CREATE DATABASE [Reward]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Reward', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Reward.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Reward_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Reward_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Reward] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Reward].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
USE [Reward]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[id] [int] NOT NULL,
	[Title] [text] NOT NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_Awards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DopTable](
	[IdAward] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_DopTable] PRIMARY KEY CLUSTERED 
(
	[IdAward] ASC,
	[IdUser] ASC
)


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [nchar](10) NOT NULL,
	[Name] [text] NOT NULL,
	[SecondName] [text] NOT NULL,
	[DateBirth] [datetime] NOT NULL,
	[Age] [int] NOT NULL,
	[AwardsList] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
ALTER TABLE [dbo].[DopTable]  WITH CHECK ADD  CONSTRAINT [FK_DopTable_DopTable] FOREIGN KEY([IdAward], [IdUser])
REFERENCES [dbo].[DopTable] ([IdAward], [IdUser])
GO
ALTER TABLE [dbo].[DopTable] CHECK CONSTRAINT [FK_DopTable_DopTable]
GO
USE [master]
GO
ALTER DATABASE [Reward] SET  READ_WRITE 
GO
