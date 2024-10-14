USE QUANLY_KHOHANG
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_HANGHOA]') AND type in (N'U'))
DROP TABLE [dbo].[tb_HANGHOA]
GO

USE QUANLY_KHOHANG
GO

-- Bật cài đặt ANSI_NULLS (đối xử với giá trị NULL theo chuẩn ANSI)
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_HANGHOA](
	[BARCODE] [nvarchar](13) NOT NULL,
	[TENHH] [nvarchar](50) NULL,
	[TENTAT] [nvarchar](50) NULL,
	[DVT] [nvarchar](50) NULL,
	[DONGIA] [float](50) NULL,
	[MANCC] [int] NULL,
	[XUATXU] [int] NULL,
	[CREATE_DATE] [datetime] NULL,
	[CREATE_BY] [int] NULL,
	[DISABLED] [bit] NULL,
    CONSTRAINT [PK_tb_HANGHOA] PRIMARY KEY CLUSTERED ([BARCODE] ASC)   -- Khóa chính cho bảng, sắp xếp theo MACTY tăng dần
)

GO