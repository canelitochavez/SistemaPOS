USE POS
GO

CREATE TYPE dbo.EDetalle_Compra AS TABLE(
IdProducto int null,
PrecioCompra decimal(18,2) null,
PrecioVenta decimal(18,2) null,
Cantidad int null,
MontoTotal decimal(18,2) null
)
GO

CREATE PROCEDURE dbo.sp_RegistrarCompra(
@IdUsuario int,
@IdProveedor int,
@TipoDocumento varchar(500),
@NumeroDocumento varchar(500),
@MontoTotal decimal(18,2),
@DetalleCompra EDetalle_Compra READONLY,
@Resultado bit out,
@Mensaje varchar(500) output
)
AS
BEGIN
	BEGIN TRY
		
		DECLARE @IdCompra INT = 0;
		
		SET @Resultado = 1;
		SET @Mensaje = '';

		BEGIN TRAN Registro;

		INSERT INTO dbo.Compra(IdUsuario,IdProveedor,TipoDocumento,NumeroDocumento,MontoTotal)
		VALUES(@IdUsuario,@IdProveedor,@TipoDocumento,@NumeroDocumento,@MontoTotal)

		SET @IdCompra = SCOPE_IDENTITY();

		INSERT INTO dbo.DetalleCompra(IdCompra,IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal)
		SELECT @IdCompra,IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal FROM @DetalleCompra;

		UPDATE P
		SET	P.Stock = P.Stock + DC.Cantidad,
			P.PrecioCompra = DC.PrecioCompra,
			P.PrecioVenta = DC.PrecioVenta
		FROM dbo.Producto P
		INNER JOIN @DetalleCompra DC
			on P.IdProducto = DC.IdProducto

		COMMIT TRAN Registro

	END TRY
	BEGIN CATCH

		ROLLBACK TRAN Registro
		SET @Resultado = 0;
		SET @Mensaje = 'No fue posible realizar la compra.'

	END CATCH
END