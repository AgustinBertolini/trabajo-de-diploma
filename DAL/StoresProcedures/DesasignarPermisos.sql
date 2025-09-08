CREATE OR ALTER PROCEDURE DesasignarPermisos
    @IdUsuario int
AS
BEGIN
    DELETE FROM usuario_permisos WHERE idUsuario = @IdUsuario;
END;