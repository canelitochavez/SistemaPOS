USE POS
GO

CREATE OR ALTER PROCEDURE dbo.sp_EditarCategoria(
@IdCategoria int,
@descripcion varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)AS
BEGIN
	SET @Resultado = 1;

	IF NOT EXISTS(SELECT 1 FROM dbo.Categoria C WHERE C.Descripcion = @descripcion AND C.IdCategoria != @IdCategoria)
	BEGIN
		UPDATE C
		SET C.Descripcion = @descripcion,
			C.Estado = @Estado
		FROM dbo.Categoria C
		WHERE C.IdCategoria = @IdCategoria
	END
	ELSE
	BEGIN
		SET @Resultado = 0;
		SET @Mensaje = 'Ya existe la Categoria.';
	END
END