CREATE TABLE Ventas (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    idCliente INT NOT NULL,
    idEnvio INT NOT NULL,
    fechaCreacion DATETIME NOT NULL,
    FOREIGN KEY (idCliente) REFERENCES Clientes(id),
    FOREIGN KEY (idEnvio) REFERENCES Envios(id),
);