CREATE OR ALTER PROCEDURE DeleteVenta
    @Id INT
AS
BEGIN
    DELETE FROM VentaItem WHERE idVenta = @Id;
	
	DELETE FROM Ventas WHERE id = @Id;

END;