CREATE OR ALTER PROCEDURE ActivarProducto
	@Id int
AS
BEGIN
   UPDATE Productos SET active = 1 WHERE id = @Id
END;