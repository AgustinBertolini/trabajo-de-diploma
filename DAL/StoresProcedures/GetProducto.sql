CREATE OR ALTER PROCEDURE GetProducto
  @Id int
AS
BEGIN
    SELECT * FROM Productos WHERE id = @Id
END;