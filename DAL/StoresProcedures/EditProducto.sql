CREATE OR ALTER PROCEDURE EditProducto
	@Id INT,
    @Nombre NVARCHAR(50),
    @Precio INT,
	@Stock INT
AS
BEGIN
    UPDATE Productos
	SET
		nombre = @Nombre,
		precio = @Precio,
		stock = @Stock,
		fechaActualizacion = getdate()
	WHERE id = @Id
END;