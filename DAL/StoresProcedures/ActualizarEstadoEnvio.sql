CREATE OR ALTER PROCEDURE ActualizarEstadoEnvio
    @Id INT,
    @EstadoEnvio NVARCHAR(30)
AS
BEGIN
    UPDATE Ventas
    SET idEnvio = (SELECT id from Envios where nombre = @EstadoEnvio)
    WHERE id = @Id;
END;
