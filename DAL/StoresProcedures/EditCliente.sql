CREATE PROCEDURE EditCliente
    @Id INT,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Cuit NVARCHAR(50),
    @Email NVARCHAR(50),
    @Direccion NVARCHAR(100),
    @TipoClienteId INT
AS
BEGIN
    UPDATE Cliente
    SET nombre = @Nombre,
        apellido = @Apellido,
        cuit = @Cuit,
        email = @Email,
        direccion = @Direccion,
        tipoClienteId = @TipoClienteId
    WHERE id = @Id
END
