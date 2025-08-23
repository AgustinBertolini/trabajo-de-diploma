CREATE OR ALTER PROCEDURE EditUsuario
	@Id int,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @DNI bigint,
	@Email NVARCHAR(100)
AS
BEGIN
    UPDATE Usuarios
	SET
		nombre = @Nombre,
		apellido = @Apellido,
		DNI = @DNI,
		email = @Email
	WHERE id = @Id
END;