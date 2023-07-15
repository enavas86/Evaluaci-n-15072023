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
-- Description:	SP para actualizar un cliente
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateCliente]
	@p_id INT,
	@p_primerNombre VARCHAR(250),
	@p_primerApellido VARCHAR(250),
	@p_edad INT
AS
BEGIN
	DECLARE @MENS_ERROR VARCHAR(250)

	BEGIN TRAN
	
	UPDATE [EVA_Clientes]
		SET	primerNombre = @p_primerNombre,
			primeroApellido = @p_primerApellido,
			edad = @p_edad
	WHERE id = @p_id

	IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			SET @MENS_ERROR = '[sp_UpdateCliente] - Error al momento de actualizar un cliente'
			RAISERROR (@MENS_ERROR, 16, 1)
		END

	COMMIT TRAN
	RETURN
END
GO
