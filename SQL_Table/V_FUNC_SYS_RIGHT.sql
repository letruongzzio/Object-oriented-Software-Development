USE [QUANLY_KHOHANG]
GO

IF EXISTS (SELECT * FROM sys.views WHERE name = N'[dbo].[V_FUNC_SYS_RIGHT]')
BEGIN
    DROP VIEW [dbo].[V_FUNC_SYS_RIGHT]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- Author:			<Author,,Name>
-- Create date:		<Create Date,,>
-- Description:		<Description,,>
-- ===============================================

CREATE VIEW [dbo].[V_FUNC_SYS_RIGHT]
AS
SELECT 
    A.FUNC_CODE, 
    A.DESCRIPTION, 
    A.ISGROUP, 
    A.PARENT, 
    A.SORT, 
    B.IDUSER, 
    CASE 
        WHEN B.USER_RIGHT = 1 THEN N'Xem' 
        WHEN B.USER_RIGHT = 2 THEN N'Toàn quyền' 
    END AS 'Không'
FROM 
    tb_SYS_FUNC A
JOIN 
    tb_SYS_RIGHT B 
ON 
    A.FUNC_CODE = B.FUNC_CODE
GO