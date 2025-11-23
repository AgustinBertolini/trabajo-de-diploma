CREATE OR ALTER PROCEDURE DuplicarCartera
	@IdUsuarioOrigen INT,
    @IdUsuarioDestino INT
AS
BEGIN
  INSERT INTO Clientes (Nombre, Apellido, Cuit, Email, Direccion, TipoClienteId, UserId, activo)
    SELECT 
        Nombre,
        Apellido,
        Cuit,
        Email,
        Direccion,
        TipoClienteId,
        @IdUsuarioDestino AS UserId,
        activo
    FROM Clientes
    WHERE UserId = @IdUsuarioOrigen;
END;