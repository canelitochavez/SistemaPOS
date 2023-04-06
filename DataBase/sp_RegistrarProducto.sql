USE POS
GO

CREATE OR ALTER PROCEDURE dbo.sp_RegistrarProducto(
@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(50),
@IdCategoria int,
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
AS

BEGIN

	SET @Resultado = 0;
	SET @Mensaje = '';

	IF NOT EXISTS (SELECT 1 FROM dbo.Producto P WHERE P.Codigo = @Codigo)
	BEGIN
		INSERT INTO dbo.Producto(Codigo,Nombre,Descripcion,IdCategoria,Estado) VALUES (@Codigo,@Nombre,@Descripcion,@IdCategoria,@Estado)
		SET @Resultado = SCOPE_IDENTITY();
	END
	ELSE
	BEGIN
		SET @Mensaje = 'El Codigo del Producto ya Existe!!!';
	END

END