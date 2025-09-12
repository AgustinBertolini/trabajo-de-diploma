CREATE TABLE Productos_Usuarios (
	id int not null primary key identity(1,1),
	idProducto INT NOT NULL,
	idUsuario INT NOT NULL,
    FOREIGN KEY (idProducto) REFERENCES Productos(id),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(id),
);