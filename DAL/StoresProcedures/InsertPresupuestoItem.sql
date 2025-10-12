CREATE OR ALTER PROCEDURE InsertPresupuestoItem
    @IdPresupuesto INT,
    @IdProducto INT,
	@Cantidad INT,
	@PrecioUnitario DECIMAL(18,2)
AS
BEGIN
    INSERT INTO PresupuestoItem(idPresupuesto, idProducto,cantidad,precioUnitario)
    VALUES (@IdPresupuesto,@IdProducto,@Cantidad,@PrecioUnitario);

    SELECT SCOPE_IDENTITY() AS IdPresupuestoItem;
END;