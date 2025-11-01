CREATE OR ALTER PROCEDURE GuardarPrecioHistorico
    @ProductId INT,
    @Precio DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Productos_Precios (idProducto, Precio, fecha)
    VALUES (@ProductId, @Precio, GETDATE())
END
