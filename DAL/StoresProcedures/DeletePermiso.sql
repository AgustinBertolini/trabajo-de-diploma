CREATE OR ALTER PROCEDURE DeletePermiso
	@Id int
AS
BEGIN
    DELETE FROM permisos_permisos WHERE idPadre = @Id;

	DELETE FROM permisos_permisos WHERE idHijo = @Id;

	DELETE FROM usuario_permisos WHERE idPermiso = @Id;

	DELETE FROM permisos WHERE id = @Id;
END;