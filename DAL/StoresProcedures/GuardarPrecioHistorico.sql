CREATE PROCEDURE GuardarPrecioHistorico
    @ProductId INT,
    @Precio INT
AS
BEGIN
    INSERT INTO Productos_Precios (idProducto, Precio, fecha)
    VALUES (@ProductId, @Precio, GETDATE())
END
