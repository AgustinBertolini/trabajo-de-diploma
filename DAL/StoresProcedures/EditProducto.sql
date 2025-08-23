CREATE OR ALTER PROCEDURE EditProducto
	@Id int,
    @Nombre NVARCHAR(50),
    @Precio INT
AS
BEGIN
    UPDATE Productos
	SET
		nombre = @Nombre,
		precio = @Precio
	WHERE id = @Id
END;