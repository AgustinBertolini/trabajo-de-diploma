CREATE TABLE VentaItem (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    idVenta INT NOT NULL,
    idProducto INT NOT NULL,
    cantidad INT NOT NULL,
    precioUnitario DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (idVenta) REFERENCES Ventas(id),
    FOREIGN KEY (idProducto) REFERENCES Productos(id),
);
