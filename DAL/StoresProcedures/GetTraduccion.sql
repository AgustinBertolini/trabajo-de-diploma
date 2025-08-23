CREATE OR ALTER PROCEDURE GetTraduccion
    @Id INT
AS
BEGIN
    SELECT 
        t.id,
        t.idIdioma,
        tags.nombre AS tag,
        t.traduccion
    FROM Traducciones t
    INNER JOIN Tags tags ON t.idTag = tags.id
    WHERE t.id = @Id;
END;
