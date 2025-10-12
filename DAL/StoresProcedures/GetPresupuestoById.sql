CREATE OR ALTER PROCEDURE GetPresupuestoById
  @Id int
AS
BEGIN
    SELECT * FROM Presupuestos WHERE id = @Id
END;