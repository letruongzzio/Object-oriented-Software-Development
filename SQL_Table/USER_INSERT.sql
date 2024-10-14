﻿USE [QUANLY_KHOHANG]
GO

-- Kiểm tra và xóa trigger nếu tồn tại
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'USER_INSERT')
BEGIN
    DROP TRIGGER [dbo].[USER_INSERT]
END
GO

-- Tạo lại trigger sau khi xóa (nếu có)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[USER_INSERT]
    ON [dbo].[tb_SYS_USER]
    AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Thêm bản ghi vào tb_SYS_RIGHT
    INSERT INTO tb_SYS_RIGHT(FUNC_CODE, IDUSER, USER_RIGHT)
    SELECT A.FUNC_CODE, B.IDUSER, 0
    FROM tb_SYS_FUNC A, tb_SYS_USER B
    WHERE B.IDUSER = (SELECT MAX(IDUSER) FROM tb_SYS_USER)

    -- Thêm bản ghi vào tb_SYS_RIGHT_REP
    INSERT INTO tb_SYS_RIGHT_REP(REP_CODE, IDUSER, USER_RIGHT)
    SELECT A.REP_CODE, B.IDUSER, 0
    FROM tb_SYS_REPORT A, tb_SYS_USER B
    WHERE B.IDUSER = (SELECT MAX(IDUSER) FROM tb_SYS_USER)
END
GO