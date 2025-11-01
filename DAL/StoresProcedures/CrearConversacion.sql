CREATE OR ALTER PROCEDURE CrearConversacion
	@IdUsuario INT
AS
BEGIN
	INSERT INTO Conversaciones (idUsuario) VALUES (@IdUsuario);

    SELECT SCOPE_IDENTITY() AS IdConversacion;

END;