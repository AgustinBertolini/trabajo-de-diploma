CREATE OR ALTER PROCEDURE InsertProducto
    @Nombre NVARCHAR(50),
    @Precio DECIMAL(18,2),
    @Stock INT
AS
BEGIN
    INSERT INTO Productos (nombre, precio,stock,fechaCreacion,fechaActualizacion)
    VALUES (@Nombre, @Precio, @Stock, getdate(), getdate());

    SELECT SCOPE_IDENTITY() AS IdProducto;
END;