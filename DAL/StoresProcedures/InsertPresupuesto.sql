CREATE OR ALTER PROCEDURE InsertPresupuesto
    @IdCliente INT,
    @FechaCreacion DATETIME
AS
BEGIN
    INSERT INTO Presupuestos(idCliente, fechaCreacion)
    VALUES (@IdCliente, @FechaCreacion);

    SELECT SCOPE_IDENTITY() AS IdPresupuesto;
END;