USE QUANLY_KHOHANG
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_DVT]') AND type in (N'U'))
DROP TABLE [dbo].[tb_DVT]
GO

USE QUANLY_KHOHANG
GO

-- Bật cài đặt ANSI_NULLS (đối xử với giá trị NULL theo chuẩn ANSI)
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_DVT](
	[ID] [int] IDENTITY(1, 1) NOT NULL,
	[TEN] [nvarchar](200) NULL,
    CONSTRAINT [PK_tb_DVT] PRIMARY KEY CLUSTERED ([ID] ASC)   -- Khóa chính cho bảng, sắp xếp theo MACTY tăng dần
)

GO