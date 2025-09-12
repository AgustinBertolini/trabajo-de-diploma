CREATE TABLE Productos_Precios (
	id int not null primary key identity(1,1),
	precio int not null,
	idProducto INT NOT NULL,
    FOREIGN KEY (idProducto) REFERENCES Productos(id),
);