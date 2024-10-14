USE QUANLY_KHOHANG
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_CHUNGTU_CT]') AND type in (N'U'))
DROP TABLE [dbo].[tb_CHUNGTU_CT]
GO

USE QUANLY_KHOHANG
GO

-- Bật cài đặt ANSI_NULLS (đối xử với giá trị NULL theo chuẩn ANSI)
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_CHUNGTU_CT](
	[KHOACT] [uniqueidentifier] NOT NULL,
	[KHOA] [uniqueidentifier] NULL,
	[NGAY] [datetime] NULL,
	[SOLUONG] [int] NULL,
	[DONGIA] [float] NULL,
	[THANHTIEN] [float] NULL,
    CONSTRAINT [PK_tb_CHUNGTU_CT] PRIMARY KEY CLUSTERED ([KHOACT] ASC)   -- Khóa chính cho bảng, sắp xếp theo MACTY tăng dần
)

GO