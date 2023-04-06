USE POS
GO

CREATE PROCEDURE dbo.sp_ModificarCliente(
@IdCliente int,
@Documento varchar(50),
@NombreCompleto varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output)
AS

BEGIN
	SET @Resultado = 1;
	SET @Mensaje = '';
	IF NOT EXISTS(SELECT 1 FROM dbo.Cliente C WHERE C.Documento = @Documento AND C.IdCliente != @IdCliente)
	BEGIN
		UPDATE dbo.Cliente
		SET Documento = @Documento,
		NombreCompleto = @NombreCompleto,
		Correo = @Correo,
		Telefono = @Telefono,
		Estado = @Estado
		WHERE IdCliente = @IdCliente
	END
	ELSE
	BEGIN
		SET @Resultado = 0;
		SET @Mensaje = 'El numero de documento ya existe';
	END
END