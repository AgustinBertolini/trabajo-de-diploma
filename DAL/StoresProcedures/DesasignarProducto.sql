CREATE PROCEDURE DesasignarProducto
    @UserId INT,
    @ProductId INT
AS
BEGIN
    DELETE FROM Productos_Usuarios
    WHERE idProducto = @ProductId AND idUsuario = @UserId
END
