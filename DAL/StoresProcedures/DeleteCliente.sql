CREATE OR ALTER PROCEDURE DeleteCliente
    @Id INT
AS
BEGIN
	UPDATE Clientes
	SET 
		activo = 0
    WHERE id = @Id
END
