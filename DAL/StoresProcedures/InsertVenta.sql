CREATE OR ALTER PROCEDURE InsertVenta
    @IdCliente INT,
    @FechaCreacion DATETIME
AS
BEGIN
    INSERT INTO Ventas(idCliente, estadoEnvio, fechaCreacion)
    VALUES (@IdCliente, 'En preparación', @FechaCreacion);

    SELECT SCOPE_IDENTITY() AS IdVenta;
END;