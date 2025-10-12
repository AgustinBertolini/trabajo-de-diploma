CREATE OR ALTER PROCEDURE GetPresupuestoItemsByPresupuestoId
  @IdPresupuesto int
AS
BEGIN
    SELECT * FROM PresupuestoItem WHERE idPresupuesto = @IdPresupuesto
END;