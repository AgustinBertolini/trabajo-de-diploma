CREATE OR ALTER PROCEDURE GetUsuarioPermisos
	@Id int
AS
BEGIN
    SELECT idPermiso FROM usuario_permisos WHERE idUsuario = @Id
END;

