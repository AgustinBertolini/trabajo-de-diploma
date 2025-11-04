CREATE OR ALTER PROCEDURE InsertVenta
    @IdCliente INT,
    @FechaCreacion DATETIME
AS
BEGIN
    INSERT INTO Ventas(idCliente, idEnvio, fechaCreacion)
    VALUES (@IdCliente, 1, @FechaCreacion);

    SELECT SCOPE_IDENTITY() AS IdVenta;
END;