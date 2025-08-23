CREATE OR ALTER PROCEDURE InsertUsuario
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @DNI bigint,
	@Email NVARCHAR(100),
	@Contrasena NVARCHAR(255)
AS
BEGIN
    INSERT INTO Usuarios (nombre, apellido, dni, email, contraseña, isActive)
    VALUES (@Nombre, @Apellido, @DNI, @Email, @Contrasena, 1);

    SELECT SCOPE_IDENTITY() AS IdUsuario;
END;