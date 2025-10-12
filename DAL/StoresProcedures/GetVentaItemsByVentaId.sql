CREATE OR ALTER PROCEDURE GetVentaItemsByVentaId
  @IdVenta int
AS
BEGIN
    SELECT * FROM VentaItem WHERE idVenta = @IdVenta
END;