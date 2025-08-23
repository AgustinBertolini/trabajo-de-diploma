CREATE TABLE Permisos_Permisos (
    idPadre INT NOT NULL,
    idHijo INT NOT NULL,
    FOREIGN KEY (idPadre) REFERENCES Permisos(id),
    FOREIGN KEY (idHijo) REFERENCES Permisos(id)
);
