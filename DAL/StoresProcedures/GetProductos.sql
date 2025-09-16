CREATE OR ALTER PROCEDURE GetProductos
AS
BEGIN
    SELECT 
     * 
    FROM Productos p
    WHERE p.active = 1
    ORDER BY p.fechaCreacion DESC
END;