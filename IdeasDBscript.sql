USE [PRT_IDEAS]

GO
/****** Object:  Table [dbo].[IdeaBox]    Script Date: 08-04-2022 10:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdeaBox](
	[idea_ID] [int] IDENTITY(100,1) NOT NULL,
	[idea_posteddate] [datetime] NOT NULL,
	[idea_tag] [varchar](50) NULL,
	[idea_mesaage] [varchar](50) NULL,
	[idea_Userid] [int] NULL,
	[liked] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idea_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERDETAILS]    Script Date: 08-04-2022 10:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERDETAILS](
	[USERID] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [varchar](50) NOT NULL,
	[USER_password] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IdeaBox] ADD  DEFAULT (getdate()) FOR [idea_posteddate]
GO

select * from [dbo].[USERDETAILS]
select * from [dbo].[IdeaBox]