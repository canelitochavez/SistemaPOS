USE POS
GO

CREATE PROCEDURE sp_EditarUsuario(
@idUsuario INT,
@documento varchar(50),
@nombreCompleto varchar(100),
@correo varchar(100),
@clave varchar(100),
@idRol int,
@estado bit,
@respuesta bit output,
@menaje varchar(500) output)

AS

BEGIN

	SET @respuesta = 0;
	SET @menaje = '';

	IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE Documento = @documento AND IdUsuario <> @idUsuario)
	BEGIN
		UPDATE dbo.Usuario
		SET Documento = @documento,
			NombreCompleto = @nombreCompleto,
			Correo = @correo,
			Clave = @clave,
			IdRol = @idRol,
			Estado = @estado
		WHERE IdUsuario = @idUsuario

		SET @respuesta = 1;
	END
	ELSE
	BEGIN
		SET @menaje = 'Ocurrio un error!!!!, Insertar un valor diferente en el campo Documento.';
	END

END