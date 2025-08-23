CREATE OR ALTER PROCEDURE EditPermiso
	@Id int,
	@Nombre VARCHAR(100),
	@EsPadre BIT
AS
BEGIN
    UPDATE Permisos
	SET
		nombre = @Nombre,
		es_padre = @EsPadre
	WHERE id = @Id
END;