USE [QUANLY_KHOHANG]
GO

IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'INSERT_REP')
BEGIN
    DROP TRIGGER [dbo].[INSERT_REP]
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

CREATE TRIGGER [dbo].[INSERT_REP]
	ON [dbo].[tb_SYS_REPORT]
	AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra results set from
	-- interfering with SELECT statements
	SET NOCOUNT ON;

	INSERT INTO tb_SYS_RIGHT_REP(REP_CODE, IDUSER, USER_RIGHT)
	SELECT A.REP_CODE, B.IDUSER, 0
	FROM tb_SYS_REPORT A, tb_SYS_USER B
	WHERE A.REP_CODE NOT IN (SELECT DISTINCT REP_CODE FROM tb_SYS_RIGHT_REP)
END

GO

