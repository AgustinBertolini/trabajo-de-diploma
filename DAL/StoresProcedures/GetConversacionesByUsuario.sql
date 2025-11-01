CREATE OR ALTER PROCEDURE GetConversacionesByUsuario
	@IdUsuario INT
AS
BEGIN
	SELECT id, idUsuario
    FROM Conversaciones
    WHERE idUsuario = @IdUsuario
END;