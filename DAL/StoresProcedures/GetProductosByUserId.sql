CREATE OR ALTER PROCEDURE GetProductosByUserId
  @Id int
AS
BEGIN
    SELECT p.* FROM Productos p INNER JOIN Productos_Usuarios pu on p.id = pu.idProducto WHERE pu.idUsuario = @Id and p.active = 1;
END;