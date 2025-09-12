CREATE OR ALTER PROCEDURE GetUsuario
  @Email NVARCHAR(255)
AS
BEGIN
    SELECT u.*, r.nombre as rolNombre FROM Usuarios u INNER JOIN Roles r on u.rolId = r.id WHERE email = @Email
END;