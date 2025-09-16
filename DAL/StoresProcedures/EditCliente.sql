ALTER PROCEDURE EditCliente
    @Id INT,
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Cuit NVARCHAR(20),
    @Email NVARCHAR(100),
    @Direccion NVARCHAR(200),
    @TipoClienteId INT,
    @UserId INT
AS
BEGIN
    UPDATE Clientes
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Cuit = @Cuit,
        Email = @Email,
        Direccion = @Direccion,
        TipoClienteId = @TipoClienteId,
        UserId = @UserId
    WHERE Id = @Id;
END