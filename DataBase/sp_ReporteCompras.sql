USE POS
GO

CREATE PROCEDURE dbo.sp_ReporteCompras(
@fechaInicio VARCHAR(10),
@fechaFin VARCHAR(10),
@idProveedor INT
)

AS

BEGIN

SELECT CONVERT(CHAR(10),C.FechaCreacion,103) AS FechaCreacion,C.TipoDocumento,C.NumeroDocumento,C.MontoTotal,
U.NombreCompleto AS UsuarioRegistro,PR.Documento AS DocumentoProveedor,PR.RazonSocial,
P.Codigo AS CodigoProducto,P.Nombre AS NombreProducto,CA.Descripcion AS Categoria,
DC.PrecioCompra,DC.PrecioVenta,DC.Cantidad,DC.MontoTotal AS SubTotal
FROM dbo.Compra C WITH (NOLOCK)
INNER JOIN dbo.Usuario U WITH (NOLOCK)
	ON C.IdUsuario = U.IdUsuario
INNER JOIN dbo.Proveedor PR WITH (NOLOCK)
	ON PR.IdProveedor = C.IdProveedor
INNER JOIN dbo.DetalleCompra DC WITH (NOLOCK)
	ON DC.IdCompra = C.IdCompra
INNER JOIN Producto P WITH (NOLOCK)
	ON P.IdProducto = DC.IdProducto
INNER JOIN dbo.Categoria CA WITH (NOLOCK)
	ON CA.IdCategoria = P.IdCategoria
WHERE 1 = 1
	AND CONVERT(DATE,C.FechaCreacion) BETWEEN @fechaInicio AND @fechaFin
		AND PR.IdProveedor = IIF(@idProveedor = 0,PR.IdProveedor,@idProveedor)
END