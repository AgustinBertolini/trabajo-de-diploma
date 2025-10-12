CREATE OR ALTER PROCEDURE DeletePresupuesto
    @Id INT
AS
BEGIN
    DELETE FROM PresupuestoItem WHERE idPresupuesto = @Id;
	
	DELETE FROM Presupuestos WHERE id = @Id;

END;