USE POS
GO

CREATE PROCEDURE dbo.sp_RegistrarCliente(
@Documento varchar(50),
@NombreCompleto varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output)
AS
BEGIN
	SET @Resultado = 0;
	SET @Mensaje = '';
	DECLARE @IdPersona INT;
	IF NOT EXISTS(SELECT 1 FROM dbo.Cliente C WHERE Documento = @Documento)
	BEGIN
		INSERT INTO dbo.Cliente(Documento,NombreCompleto,Correo,Telefono,Estado) VALUES(@Documento,@NombreCompleto,@Correo,@Telefono,@Estado)
		SET @Resultado = SCOPE_IDENTITY();
	END
	ELSE
	BEGIN
		SET @Mensaje = 'El numero de documento ya existe';
	END
END