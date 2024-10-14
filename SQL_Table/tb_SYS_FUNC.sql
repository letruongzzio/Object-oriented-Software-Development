USE QUANLY_KHOHANG
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_SYS_FUNC]') AND type in (N'U'))
DROP TABLE [dbo].[tb_SYS_FUNC]
GO

USE QUANLY_KHOHANG
GO

-- Bật cài đặt ANSI_NULLS (đối xử với giá trị NULL theo chuẩn ANSI)
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tb_SYS_FUNC](
	[FUNC_CODE] [varchar](50) NOT NULL,
	[SORT] [int] NULL,
	[DESCRIPTION] [nvarchar](200) NULL,
	[ISGROUP] [bit] NULL,
	[PARENT] [varchar](50) NULL,
	[MENU] [varchar](max) NULL,
	[TIPS] [varchar](max) NULL,
    CONSTRAINT [PK_tb_SYS_FUNC] PRIMARY KEY CLUSTERED ([FUNC_CODE] ASC)
)

GO