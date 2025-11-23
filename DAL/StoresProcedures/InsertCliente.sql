CREATE OR ALTER PROCEDURE InsertCliente
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Cuit NVARCHAR(20),
    @Email NVARCHAR(100),
    @Direccion NVARCHAR(200),
    @TipoClienteId INT,
    @UserId INT
AS
BEGIN
    INSERT INTO Clientes (Nombre, Apellido, Cuit, Email, Direccion, TipoClienteId, UserId, activo)
    VALUES (@Nombre, @Apellido, @Cuit, @Email, @Direccion, @TipoClienteId, @UserId,1);

    SELECT SCOPE_IDENTITY();
END