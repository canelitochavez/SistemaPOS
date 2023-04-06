USE [POS]
GO


CREATE PROCEDURE [dbo].[sp_RegistrarVenta](
@IdUsuario int,
@TipoDocumento varchar(500),
@NumeroDocumento varchar(500),
@DocumentoCliente varchar(500),
@NombreCliente varchar(500),
@Efectivo decimal(18,2),
@Cambio decimal(18,2),
@Total decimal(18,2),
@DetalleVenta EDetalle_Venta READONLY,
@Resultado bit out,
@Mensaje varchar(500) output
)
AS
BEGIN
	BEGIN TRY
		
		DECLARE @IdVenta INT = 0;
		
		SET @Resultado = 1;
		SET @Mensaje = '';

		BEGIN TRAN Registro;

		INSERT INTO dbo.Venta(IdUsuario,TipoDocumento,NumeroDocumento,DocumentoCliente,NombreCliente,MontoPago,MontoCambio,MontoTotal)
		VALUES(@IdUsuario,@TipoDocumento,@NumeroDocumento,@DocumentoCliente,@NombreCliente,@Efectivo,@Cambio,@Total)

		SET @IdVenta = SCOPE_IDENTITY();

		INSERT INTO dbo.DetalleVenta(IdVenta,IdProducto,PrecioVenta,Cantidad,SubTotal)
		SELECT @IdVenta,IdProducto,PrecioVenta,Cantidad,SubTotal FROM @DetalleVenta;

		COMMIT TRAN Registro

	END TRY
	BEGIN CATCH

		ROLLBACK TRAN Registro
		SET @Resultado = 0;
		SET @Mensaje = 'No fue posible realizar la venta.'

	END CATCH
END