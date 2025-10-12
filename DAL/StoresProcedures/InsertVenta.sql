CREATE OR ALTER PROCEDURE InsertVenta
    @IdCliente INT,
    @FechaCreacion DATETIME
AS
BEGIN
    INSERT INTO Ventas(idCliente, estadoEnvio, fechaCreacion)
    VALUES (@IdCliente, 'En preparaci�n', @FechaCreacion);

    SELECT SCOPE_IDENTITY() AS IdVenta;
END;