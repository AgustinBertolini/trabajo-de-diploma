CREATE OR ALTER PROCEDURE DeleteUsuario
	@Id int
AS
BEGIN
    UPDATE Usuarios
	SET
		isActive = 0
	WHERE id = @Id
END;