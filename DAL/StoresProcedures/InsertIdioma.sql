CREATE OR ALTER PROCEDURE InsertIdioma
    @Nombre NVARCHAR(50)
AS
BEGIN
    INSERT INTO Idiomas (nombre)
    VALUES (@Nombre);

    DECLARE @IdNuevoIdioma INT = SCOPE_IDENTITY();

    INSERT INTO Traducciones (idIdioma, idTag, traduccion)
    SELECT 
        @IdNuevoIdioma,
        t.idTag,
        t.traduccion
    FROM Traducciones t
    WHERE t.idIdioma = (SELECT id FROM Idiomas WHERE Nombre = 'Español');

    SELECT @IdNuevoIdioma AS IdIdioma;
END;