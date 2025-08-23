CREATE OR ALTER PROCEDURE EditIdioma
	@Id int,
	@Nombre VARCHAR(100)
AS
BEGIN
    UPDATE Idiomas
	SET
		nombre = @Nombre
	WHERE id = @Id
END;