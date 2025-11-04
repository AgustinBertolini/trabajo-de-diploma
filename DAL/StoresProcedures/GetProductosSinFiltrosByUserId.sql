CREATE OR ALTER PROCEDURE GetProductosSinFiltrosByUserId
AS
BEGIN
   SELECT p.* FROM Productos p INNER JOIN Productos_Usuarios pu on p.id = pu.idProducto WHERE pu.idUsuario = @Id;
END;