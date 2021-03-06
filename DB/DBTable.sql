USE [Bruce]
GO
/****** Object:  Table [dbo].[douban_subject]    Script Date: 01/23/2017 11:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[douban_subject](
	[id] [nchar](10) NOT NULL,
	[types] [nvarchar](50) NULL,
	[release_year] [nchar](10) NULL,
	[playable] [bit] NULL,
	[region] [nchar](10) NULL,
	[duration] [nchar](10) NULL,
	[actors] [nvarchar](256) NULL,
	[directors] [nvarchar](256) NULL,
	[subtype] [nchar](10) NULL,
	[is_tv] [bit] NULL,
	[rate] [nchar](10) NULL,
	[collection_status] [nchar](10) NULL,
	[url] [nvarchar](256) NULL,
	[title] [nvarchar](256) NULL,
	[blacklisted] [nchar](10) NULL,
	[star] [nchar](10) NULL,
	[episodes_count] [nchar](10) NULL,
	[actors_id] [nvarchar](256) NULL,
	[directors_id] [nvarchar](256) NULL,
	[bianjus] [nvarchar](256) NULL,
	[bianjus_id] [nvarchar](256) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[douban_search_subject]    Script Date: 01/23/2017 11:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[douban_search_subject](
	[id] [nchar](10) NOT NULL,
	[rate] [nchar](10) NULL,
	[cover_x] [int] NULL,
	[cover_y] [int] NULL,
	[title] [nvarchar](512) NULL,
	[url] [nvarchar](512) NULL,
	[cover] [nvarchar](512) NULL,
	[is_beetle_subject] [bit] NULL,
	[playable] [bit] NULL,
	[is_new] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[douban_celebrity]    Script Date: 01/23/2017 11:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[douban_celebrity](
	[id] [nchar](10) NULL,
	[name] [nvarchar](50) NULL,
	[title] [nvarchar](50) NULL,
	[sex] [nvarchar](50) NULL,
	[birthday] [nvarchar](50) NULL,
	[constellation] [nvarchar](50) NULL,
	[occupation] [nvarchar](50) NULL,
	[homeplace] [nvarchar](512) NULL,
	[chname] [nvarchar](512) NULL,
	[othernames] [nvarchar](512) NULL,
	[imdbnum] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[douban_cele_subject]    Script Date: 01/23/2017 11:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[douban_cele_subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[celebrity_id] [nchar](10) NULL,
	[subject_id] [nchar](10) NULL,
	[subject_title] [nvarchar](50) NULL
) ON [PRIMARY]
GO
