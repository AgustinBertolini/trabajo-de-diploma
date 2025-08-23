CREATE OR ALTER PROCEDURE DeleteProducto
	@Id int
AS
BEGIN
    DELETE FROM Productos WHERE id = @Id
END;