CREATE OR ALTER PROCEDURE InsertVentaItem
    @IdVenta INT,
    @IdProducto INT,
	@Cantidad INT,
	@PrecioUnitario DECIMAL(18,2)
AS
BEGIN
    INSERT INTO VentaItem(idVenta, idProducto,cantidad,precioUnitario)
    VALUES (@IdVenta,@IdProducto,@Cantidad,@PrecioUnitario);

	UPDATE Productos
	SET
		stock = stock - @Cantidad
	WHERE id = @IdProducto;

    SELECT SCOPE_IDENTITY() AS IdVentaItem;
END;