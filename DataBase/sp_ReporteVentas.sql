USE POS
GO

CREATE PROCEDURE dbo.sp_ReporteVentas(
@fechaInicio VARCHAR(10),
@fechaFin VARCHAR(10)
)

AS

BEGIN

SELECT CONVERT(CHAR(10),V.FechaCreacion,103) AS FechaCreacion,V.TipoDocumento,V.NumeroDocumento,V.MontoTotal,
U.NombreCompleto AS UsuarioRegistro,V.DocumentoCliente,V.NombreCliente,
P.Codigo AS CodigoProducto,P.Nombre AS NombreProducto,CA.Descripcion AS Categoria,
DV.PrecioVenta,DV.Cantidad,DV.SubTotal AS SubTotal
FROM dbo.Venta V WITH (NOLOCK)
INNER JOIN dbo.Usuario U WITH (NOLOCK)
	ON V.IdUsuario = U.IdUsuario
INNER JOIN dbo.DetalleVenta DV WITH (NOLOCK)
	ON DV.IdVenta = V.IdVenta
INNER JOIN Producto P WITH (NOLOCK)
	ON P.IdProducto = DV.IdProducto
INNER JOIN dbo.Categoria CA WITH (NOLOCK)
	ON CA.IdCategoria = P.IdCategoria
WHERE 1 = 1
	AND CONVERT(DATE,V.FechaCreacion) BETWEEN @fechaInicio AND @fechaFin
END