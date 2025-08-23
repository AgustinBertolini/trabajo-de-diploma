CREATE OR ALTER PROCEDURE AsignarPermiso
    @IdUsuario int,
    @IdPermiso int
AS
BEGIN
  IF NOT EXISTS (
        SELECT 1
        FROM usuario_permisos
        WHERE idUsuario = @IdUsuario AND idPermiso = @IdPermiso
    )
    BEGIN
    INSERT INTO usuario_permisos (idUsuario, idPermiso) VALUES (@IdUsuario, @IdPermiso);
    END
END;