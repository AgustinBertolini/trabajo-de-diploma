CREATE OR ALTER PROCEDURE InsertProducto
    @Nombre NVARCHAR(50),
    @Precio INT
AS
BEGIN
    INSERT INTO Productos (nombre, precio)
    VALUES (@Nombre, @Precio);

    SELECT SCOPE_IDENTITY() AS IdProducto;
END;