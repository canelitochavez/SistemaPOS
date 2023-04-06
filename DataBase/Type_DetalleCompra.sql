USE POS
GO

CREATE TYPE dbo.EDetalle_Compra AS TABLE(
IdProducto int null,
PrecioCompra decimal(18,2) null,
PrecioVenta decimal(18,2) null,
Cantidad int null,
MontoTotal decimal(18,2) null)

