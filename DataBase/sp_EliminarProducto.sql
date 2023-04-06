USE POS
GO

CREATE PROCEDURE dbo.sp_EliminarProducto(
@IdProducto int,
@Resultado bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
	
	SET @Resultado = 0;
	SET @Mensaje = '';

	DECLARE @CheckFields BIT = 1

	IF EXISTS(SELECT 1 FROM dbo.DetalleCompra DC INNER JOIN dbo.Producto P ON DC.IdProducto = P.IdProducto WHERE P.IdProducto = @IdProducto)
	BEGIN
		
		SET @CheckFields = 0;
		SET @Resultado = 0;
		SET @Mensaje = 'No se puede Eliminar el Producto porque se encuentra relacionado a una Compra\n';
	END

	IF EXISTS(SELECT 1 FROM dbo.DetalleVenta DV INNER JOIN dbo.Producto P ON DV.IdProducto = P.IdProducto WHERE P.IdProducto = @IdProducto)
	BEGIN
		
		SET @CheckFields = 0;
		SET @Resultado = 0;
		SET @Mensaje = 'No se puede Eliminar el Producto porque se encuentra relacionado a una Venta\n';
	END

	IF(@CheckFields = 1 )
	BEGIN
		DELETE FROM dbo.Producto WHERE IdProducto = @IdProducto;
		SET @Resultado = 1;
	END

END