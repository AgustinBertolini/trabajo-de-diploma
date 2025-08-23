CREATE OR ALTER PROCEDURE InsertPermiso
    @Nombre NVARCHAR(50),
    @EsPadre BIT
AS
BEGIN
    INSERT INTO Permisos (nombre, es_padre)
    VALUES (@Nombre, @EsPadre);

    SELECT SCOPE_IDENTITY() AS IdPermiso;
END;