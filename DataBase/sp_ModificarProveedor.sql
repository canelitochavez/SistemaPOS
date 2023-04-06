USE POS
GO

CREATE PROCEDURE dbo.sp_ModificarProveedor(
@IdProveedor int,
@Documento varchar(50),
@RazonSocial varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
	SET @Resultado = 1;
	SET @Mensaje = '';

	IF NOT EXISTS(SELECT 1 FROM dbo.Proveedor P WHERE P.Documento = @Documento AND P.IdProveedor != @IdProveedor)
	BEGIN
		UPDATE dbo.Proveedor
		SET Documento = @Documento,
			RazonSocial = @RazonSocial,
			Correo = @Correo,
			Telefono = @Telefono,
			Estado = @Estado
			WHERE IdProveedor = @IdProveedor
	END
	ELSE
	BEGIN
		SET @Resultado = 0;
		SET @Mensaje = 'El numero de Documento ya Existe.';
	END
END