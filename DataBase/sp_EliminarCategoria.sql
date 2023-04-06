USE POS
GO

CREATE OR ALTER PROCEDURE dbo.sp_EliminarCategoria(
@IdCategoria int,
@Resultado bit output,
@Mensaje varchar(500) output
)AS
BEGIN
	SET @Resultado = 1;

	IF NOT EXISTS(SELECT 1 
					FROM dbo.Categoria C 
					INNER JOIN dbo.Producto P 
						ON C.IdCategoria = P.IdCategoria
					WHERE C.IdCategoria = @IdCategoria)
	BEGIN
		DELETE C
		FROM dbo.Categoria C
		WHERE C.IdCategoria = @IdCategoria
	END
	ELSE
	BEGIN
		SET @Resultado = 0;
		SET @Mensaje = 'No fue posible ELIMINAR la Catgoria, porque se encuentra relacionada a un Producto.';
	END
END