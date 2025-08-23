CREATE OR ALTER PROCEDURE InsertTraduccionHistorico
    @ValorViejo NVARCHAR(200),
    @ValorNuevo NVARCHAR(200),
    @IdTraduccion INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Traducciones_Historico (fecha, valorViejo, valorNuevo, idTraduccion)
    VALUES (GETDATE(), @ValorViejo, @ValorNuevo, @IdTraduccion);

    IF (
        SELECT COUNT(*) 
        FROM Traducciones_Historico
    ) > 5
    BEGIN
        DELETE FROM Traducciones_Historico
        WHERE fecha = (
            SELECT MIN(fecha) FROM Traducciones_Historico
        );
    END
END;
