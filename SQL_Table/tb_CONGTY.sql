USE QUANLY_KHOHANG
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_CONGTY]') AND type in (N'U'))
DROP TABLE [dbo].[tb_Congty]
GO

USE QUANLY_KHOHANG
GO

-- Bật cài đặt ANSI_NULLS (đối xử với giá trị NULL theo chuẩn ANSI)
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_CONGTY](
	[MACTY] [nvarchar](10) NOT NULL,
	[TENCTY] [nvarchar](200) NULL,
	[DIENTHOAI] [nvarchar](20) NULL,
	[EMAIL] [nvarchar](50) NULL,
	[FAX] [nvarchar](20) NULL,
	[DIACHI] [nvarchar](500) NULL,
	[DISABLE] [bit] NULL,
    CONSTRAINT [PK_tb_CONGTY] PRIMARY KEY CLUSTERED ([MACTY] ASC)   -- Khóa chính cho bảng, sắp xếp theo MACTY tăng dần
)

GO