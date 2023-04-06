USE POS
GO

CREATE PROCEDURE sp_EliminarUsuario(
@idUsuario INT,
@respuesta bit output,
@menaje varchar(500) output)

AS

BEGIN

	SET @respuesta = 0;
	SET @menaje = '';

	DECLARE @eliminarUsuario BIT = 1;

	IF EXISTS (SELECT 1 FROM dbo.Compra C INNER JOIN dbo.Usuario U On C.IdUsuario = U.IdUsuario WHERE U.IdUsuario = @idUsuario)
	BEGIN
		SET @eliminarUsuario = 0;
		SET @respuesta = 0;
		SET @menaje = @menaje + 'No se puede eliminar un Usuario relacionado a una compra\n.';
	END

	IF EXISTS (SELECT 1 FROM dbo.Venta V INNER JOIN dbo.Usuario U On V.IdUsuario = U.IdUsuario WHERE U.IdUsuario = @idUsuario)
	BEGIN
		SET @eliminarUsuario = 0;
		SET @respuesta = 0;
		SET @menaje = @menaje + 'No se puede eliminar un Usuario relacionado a una venta\n.';
	END

	IF (@eliminarUsuario = 1)
	BEGIN
		DELETE FROM dbo.Usuario WHERE IdUsuario = @idUsuario
		SET @respuesta = 1;
	END
END