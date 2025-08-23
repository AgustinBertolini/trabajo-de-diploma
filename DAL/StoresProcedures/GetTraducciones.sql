CREATE OR ALTER PROCEDURE GetTraducciones
    @IdIdioma INT
AS
BEGIN
    SELECT 
        t.id,
        t.idIdioma,
        tags.nombre AS Tag,
        t.traduccion
    FROM Traducciones t
    INNER JOIN Tags tags ON t.idTag = tags.id
    WHERE t.idIdioma = @IdIdioma
END;
