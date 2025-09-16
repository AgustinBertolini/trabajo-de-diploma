CREATE PROCEDURE InsertCliente
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Cuit NVARCHAR(50),
    @Email NVARCHAR(50),
    @Direccion NVARCHAR(100),
    @TipoClienteId INT
AS
BEGIN
    INSERT INTO Cliente (nombre, apellido, cuit, email, direccion, tipoClienteId)
    VALUES (@Nombre, @Apellido, @Cuit, @Email, @Direccion, @TipoClienteId)
    SELECT SCOPE_IDENTITY()
END
