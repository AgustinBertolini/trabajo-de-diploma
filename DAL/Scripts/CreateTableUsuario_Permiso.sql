CREATE TABLE Usuario_Permisos (
    idUsuario INT NOT NULL,
    idPermiso INT NOT NULL,
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(id),
    FOREIGN KEY (idPermiso) REFERENCES Permisos(id)
);
