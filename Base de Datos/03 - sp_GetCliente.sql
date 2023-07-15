-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Edwin Navas
-- Create date: 15.07.2023
-- Description:	SP para obtener un solo cliente
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetCliente]
	@p_id INT
AS
BEGIN
	SELECT *
	FROM [EVA_Clientes]
	WHERE id = @p_id
END
GO
