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
-- Description:	SP para listar a los clientes
-- =============================================
CREATE PROCEDURE [dbo].[sp_ListClientes]
	
AS
BEGIN
	SELECT *
	FROM [EVALUACION15072023].[dbo].[EVA_Clientes]
	ORDER BY id
END
GO
