CREATE PROCEDURE AsignarProducto
    @UserId INT,
    @ProductId INT
AS
BEGIN
    INSERT INTO Productos_Usuarios (idProducto, idUsuario)
    VALUES (@ProductId, @UserId)
END
