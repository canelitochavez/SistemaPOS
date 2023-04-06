USE POS
GO

CREATE TYPE dbo.EDetalle_Venta AS TABLE(
IdProducto int null,
PrecioVenta decimal(18,2) null,
Cantidad int null,
SubTotal decimal(18,2) null)

