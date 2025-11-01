CREATE TABLE Envios (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL
);

GO

INSERT INTO Envios (nombre) VALUES ('En preparación');
INSERT INTO Envios (nombre) VALUES ('Entregado');
INSERT INTO Envios (nombre) VALUES ('En camino');