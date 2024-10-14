USE QUANLY_KHOHANG
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_SYS_USER]') AND type in (N'U'))
DROP TABLE [dbo].[tb_SYS_USER]
GO

USE QUANLY_KHOHANG
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tb_SYS_USER](
	[IDUSER] [int]	IDENTITY(1, 1) NOT NULL,
	[USERNAME] [varchar](50) NULL,
	[PASSWD] [varchar](50) NULL,
	[FULLNAME] [nvarchar](255) NULL,
	[MACTY] [nvarchar](10) NOT NULL,
	[MADVI] [nvarchar](10) NOT NULL,
	[LAST_PWD_CHANGED] [datetime] NULL,
	[DISABLED] [bit] NULL,
	[ISGROUP] [bit] NULL, 
    CONSTRAINT [PK_tb_SYS_USER] PRIMARY KEY CLUSTERED ([IDUSER] ASC)
)

GO