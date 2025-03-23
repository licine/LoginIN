USE [test01]
GO

/****** Object:  Table [dbo].[FileInfo]    Script Date: 2025/3/23 23:59:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FileInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[修改日期] [varchar](50) NULL,
	[文件类型] [nvarchar](50) NULL,
	[大小] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[LoginAccount]    Script Date: 2025/3/24 0:00:09 ******/

CREATE TABLE [dbo].[LoginAccount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[pas] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Student]    Script Date: 2025/3/24 0:00:47 ******/

CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Snumber] [nvarchar](50) NULL,
	[Sname] [nvarchar](50) NULL,
	[Sclass] [nvarchar](50) NULL,
	[数据结构] [float] NULL,
	[c] [float] NULL,
	[java] [float] NULL,
	[linux] [float] NULL
) ON [PRIMARY]
GO