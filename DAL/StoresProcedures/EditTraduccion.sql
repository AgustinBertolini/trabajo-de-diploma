CREATE OR ALTER PROCEDURE EditTraduccion
    @Id INT,
    @Valor NVARCHAR(100)
AS
BEGIN
    UPDATE Traducciones
    SET traduccion = @Valor
    WHERE id = @Id;
END;
