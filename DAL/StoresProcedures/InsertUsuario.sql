CREATE OR ALTER PROCEDURE InsertUsuario
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @DNI bigint,
	@Email NVARCHAR(100),
	@Contrasena NVARCHAR(255),
    @RolId int
AS
BEGIN
    INSERT INTO Usuarios (nombre, apellido, dni, email, contraseña, isActive, rolId)
    VALUES (@Nombre, @Apellido, @DNI, @Email, @Contrasena, 1, @RolId);

    SELECT SCOPE_IDENTITY() AS IdUsuario;
END;