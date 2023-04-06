USE POS
GO

CREATE PROCEDURE dbo.sp_EliminarProveedor(
@IdProveedor int,
@Resultado bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
	SET @Resultado = 1;
	SET @Mensaje = '';

	IF NOT EXISTS(SELECT 1 FROM dbo.Proveedor P Inner Join dbo.Compra C On P.IdProveedor = C.IdProveedor Where P.IdProveedor = @IdProveedor)
	BEGIN
		DELETE TOP(1) FROM dbo.Proveedor WHERE IdProveedor = @IdProveedor
	END
	ELSE
	BEGIN
		SET @Resultado = 0;
		SET @Mensaje = 'El Proveedor se encuentra relacionado a una Compra.';
	END
END