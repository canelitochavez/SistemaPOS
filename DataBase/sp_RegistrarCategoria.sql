USE POS
GO

CREATE OR ALTER PROCEDURE dbo.sp_RegistrarCategoria(
@descripcion varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)AS
BEGIN
	SET @Resultado = 0;

	IF NOT EXISTS(SELECT 1 FROM dbo.Categoria C WHERE C.Descripcion = @descripcion)
	BEGIN
		INSERT INTO dbo.Categoria(Descripcion,Estado) VALUES(@descripcion,@Estado)
		SET @Resultado = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SET @Mensaje = 'Ya existe la Categoria.'
	END
END