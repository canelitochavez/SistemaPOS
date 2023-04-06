USE POS
GO

ALTER PROCEDURE sp_RegistrarUsuario(
@documento varchar(50),
@nombreCompleto varchar(100),
@correo varchar(100),
@clave varchar(100),
@idRol int,
@estado bit,
@idUsuarioResultado int output,
@menaje varchar(500) output)

AS

BEGIN

	SET @idUsuarioResultado = 0;
	SET @menaje = '';

	IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE Documento = @documento)
	BEGIN
		INSERT INTO dbo.Usuario(Documento,NombreCompleto,Correo,Clave,IdRol,Estado)
		VALUES (@documento,@nombreCompleto,@correo,@clave,@idRol,@estado)

		SET @idUsuarioResultado = SCOPE_IDENTITY();
	END
	ELSE
	BEGIN
		SET @menaje = 'Ocurrio un error!!!!, Insertar un valor diferente en el campo Documento.';
	END

END