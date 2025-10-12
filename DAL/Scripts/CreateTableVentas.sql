CREATE TABLE Ventas (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    idCliente INT NOT NULL,
    estadoEnvio NVARCHAR(30) NOT NULL,
    fechaCreacion DATETIME NOT NULL,
    FOREIGN KEY (idCliente) REFERENCES Clientes(id),
);