USE QUANLY_KHOHANG
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_CHUNGTU]') AND type in (N'U'))
DROP TABLE [dbo].[tb_CHUNGTU]
GO

USE QUANLY_KHOHANG
GO

-- Bật cài đặt ANSI_NULLS (đối xử với giá trị NULL theo chuẩn ANSI)
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_CHUNGTU](
	[KHOA] [uniqueidentifier] NOT NULL,
	[SCT] [nvarchar](50) NULL,
	[NGAY] [datetime] NULL,
	[SCT2] [nvarchar](50) NULL,
	[NGAY2] [datetime] NULL,
	[SOLUONG] [int] NULL,
	[TONGTIEN] [float] NULL,
	[GHICHU] [nvarchar](50) NULL,
	[MACTY] [nvarchar](50) NULL,
	[MADVI] [nvarchar](50) NULL,
	[MADVI2] [nvarchar](50) NULL,
	[TRANGTHAI] [bit] NULL,
	[CREATED_DATE] [datetime] NULL,
	[CREATED_BY] [int] NULL,
	[UPDATED_DATE] [datetime] NULL,
	[UPDATED_BY] [int] NULL,
	[DELETED_DATE] [datetime] NULL,
	[DELETED_BY] [int] NULL,
    CONSTRAINT [PK_tb_CHUNGTU] PRIMARY KEY CLUSTERED ([KHOA] ASC)   -- Khóa chính cho bảng, sắp xếp theo MACTY tăng dần
)

GO