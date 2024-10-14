USE QUANLY_KHOHANG
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_NHACUNGCAP]') AND type in (N'U'))
DROP TABLE [dbo].[tb_NHACUNGCAP]
GO

USE QUANLY_KHOHANG
GO

-- Bật cài đặt ANSI_NULLS (đối xử với giá trị NULL theo chuẩn ANSI)
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_NHACUNGCAP](
	[MANCC] [int] IDENTITY(1, 1) NOT NULL,
	[TENNCC] [nvarchar](200) NULL,
	[DIENTHOAI] [nvarchar](20) NULL,
	[FAX] [nvarchar](50) NULL,
	[EMAIL] [nvarchar](50) NULL,
	[DIACHI] [nvarchar](500) NULL,
	[CREATE_DATE] [datetime] NULL,
	[DISABLE] [bit] NULL,
    CONSTRAINT [PK_tb_NHACUNGCAP] PRIMARY KEY CLUSTERED ([MANCC] ASC)   -- Khóa chính cho bảng, sắp xếp theo MACTY tăng dần
)

GO