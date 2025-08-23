CREATE OR ALTER PROCEDURE InsertBitacora
    @Mensaje NVARCHAR(200),
    @TipoEvento NVARCHAR(200),
    @IdUsuario int
AS
BEGIN
    INSERT INTO Bitacora (mensaje, tipoEvento, idUsuario, fecha)
    VALUES (@Mensaje, @TipoEvento, @IdUsuario, getdate());

    SELECT SCOPE_IDENTITY() AS IdUsuario;
END;