CREATE TABLE Bitacora (
    id int identity(1,1) primary key not null,
    fecha datetime not null,
    mensaje nvarchar(200) not null,
    tipoEvento nvarchar(200) not null,
    idUsuario INT NOT NULL,
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(id)
);
