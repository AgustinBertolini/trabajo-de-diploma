CREATE OR ALTER PROCEDURE VincularPermisos
    @IdPadre int,
    @IdHijo int
AS
BEGIN
  IF NOT EXISTS (
        SELECT 1
        FROM permisos_permisos
        WHERE idPadre = @IdPadre AND idHijo = @IdHijo
    )
    BEGIN
    INSERT INTO permisos_permisos (idPadre, idHijo) VALUES (@IdPadre, @IdHijo);
    END
END;