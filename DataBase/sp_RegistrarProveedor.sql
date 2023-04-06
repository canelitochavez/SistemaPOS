USE POS
GO

CREATE PROCEDURE dbo.sp_RegistrarProveedor(
@Documento varchar(50),
@RazonSocial varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
AS
BEGIN
	SET @Resultado = 0;
	SET @Mensaje = '';
	IF NOT EXISTS (SELECT 1 FROM dbo.Proveedor WHERE Documento = @Documento)
	BEGIN
		INSERT INTO dbo.Proveedor(Documento,RazonSocial,Correo,Telefono,Estado) VALUES(@Documento,@RazonSocial,@Correo,@Telefono,@Estado)
		SET @Resultado = SCOPE_IDENTITY();
	END
	ELSE
	BEGIN
		SET @Mensaje = 'El numero de Documento ya Existe.';
	END
END
GO

