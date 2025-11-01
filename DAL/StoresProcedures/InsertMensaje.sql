CREATE OR ALTER PROCEDURE InsertMensaje
	@IdConversacion INT,
	@IdEmisor INT,
	@Mensaje NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO Conversaciones_Mensajes (idConversacion, idEmisor, mensaje, fechaEnvio)
    VALUES (@IdConversacion, @IdEmisor, @Mensaje, GETDATE());
    SELECT SCOPE_IDENTITY();
END