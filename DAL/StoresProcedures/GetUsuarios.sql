CREATE OR ALTER PROCEDURE GetUsuarios
AS
BEGIN
    SELECT u.*, r.nombre as rolNombre FROM Usuarios u INNER JOIN Roles r on u.rolId = r.id WHERE isActive = 1
END;