CREATE PROCEDURE GetProductoVendedores
    @Id INT
AS
BEGIN
    SELECT
        p.id as idProducto,
        p.nombre as ProductoNombre,
        pu.idUsuario,
        u.Nombre,
        u.Apellido,
        u.Email
    FROM Productos p 
    INNER JOIN Productos_Usuarios pu on pu.idProducto = p.id 
    INNER JOIN Usuarios u on u.id = pu.idUsuario
    WHERE p.id = @Id
END
