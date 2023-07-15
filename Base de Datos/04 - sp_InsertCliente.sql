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
-- Description:	SP para ingresar un nuevo cliente
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertCliente]
	@p_primerNombre VARCHAR(250),
	@p_primerApellido VARCHAR(250),
	@p_edad INT
AS
BEGIN
	DECLARE @MENS_ERROR VARCHAR(250)

	BEGIN TRAN
	
	INSERT INTO [EVA_Clientes] (primerNombre, primeroApellido, edad)
		VALUES (@p_primerNombre, @p_primerApellido, @p_edad)

	IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			SET @MENS_ERROR = '[sp_InsertCliente] - Error al momento de ingresar el nuevo cliente'
			RAISERROR (@MENS_ERROR, 16, 1)
		END

	COMMIT TRAN
	RETURN
END
GO
