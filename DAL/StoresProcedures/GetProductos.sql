CREATE OR ALTER PROCEDURE GetProductos
AS
BEGIN
    SELECT 
        * 
    FROM Productos p
    LEFT JOIN Productos_Precios pp on pp.idProducto = p.id
    LEFT JOIN Productos_Usuarios pu on pu.idProducto = p.id
    WHERE p.active = 1
    ORDER BY p.fechaCreacion DESC
END;