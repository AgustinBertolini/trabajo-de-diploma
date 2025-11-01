CREATE OR ALTER PROCEDURE GetProductosSinFiltros
AS
BEGIN
    SELECT 
     * 
    FROM Productos p
    ORDER BY p.fechaCreacion DESC
END;