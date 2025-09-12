CREATE OR ALTER PROCEDURE DeleteProducto
	@Id int
AS
BEGIN
   UPDATE Productos SET active = 0 WHERE id = @Id
END;