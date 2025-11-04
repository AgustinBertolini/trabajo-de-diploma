CREATE OR ALTER PROCEDURE DuplicarCartera
	@IdUsuarioOrigen INT,
    @IdUsuarioDestino INT
AS
BEGIN
  INSERT INTO Clientes (Nombre, Apellido, Cuit, Email, Direccion, TipoClienteId, UserId)
    SELECT 
        Nombre,
        Apellido,
        Cuit,
        Email,
        Direccion,
        TipoClienteId,
        @IdUsuarioDestino AS UserId
    FROM Clientes
    WHERE UserId = @IdUsuarioOrigen;
END;