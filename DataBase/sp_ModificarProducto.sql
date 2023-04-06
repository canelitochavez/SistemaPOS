USE POS
GO

CREATE PROCEDURE dbo.sp_ModificarProducto(
@IdProducto int,
@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(50),
@IdCategoria int,
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)
AS

BEGIN

	SET @Resultado = 1;

	IF NOT EXISTS(SELECT 1 FROM dbo.Producto P WHERE P.Codigo = @Codigo AND IdProducto != @IdProducto)
	BEGIN
		UPDATE dbo.Producto
		SET Codigo = @Codigo,	
			Nombre = @Nombre,
			Descripcion = @Descripcion,
			IdCategoria = @IdCategoria,
			Estado = @Estado
		WHERE IdProducto = @IdProducto
	END
	ELSE
	BEGIN
		SET @Resultado = 0;
		SET @Mensaje = 'El Codigo del Producto ya Existe!!!';
	END

END