CREATE OR ALTER PROCEDURE ActualizarEstadoEnvio
    @Id INT,
    @EstadoEnvio NVARCHAR(30)
AS
BEGIN
    UPDATE Ventas
    SET estadoEnvio = @EstadoEnvio
    WHERE id = @Id;
END;
