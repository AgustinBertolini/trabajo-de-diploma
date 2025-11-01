CREATE OR ALTER PROCEDURE GetMensajesByConversacion
	@IdConversacion INT
AS
BEGIN
	SELECT id, idConversacion, idEmisor, mensaje, fechaEnvio
	FROM Conversaciones_Mensajes
	WHERE idConversacion = @IdConversacion
	ORDER BY fechaEnvio ASC
END;