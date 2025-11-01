CREATE OR ALTER PROCEDURE GetConversaciones
AS
BEGIN
	SELECT id, idUsuario
    FROM Conversaciones
END;