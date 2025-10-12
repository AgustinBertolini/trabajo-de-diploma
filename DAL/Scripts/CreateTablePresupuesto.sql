CREATE TABLE Presupuestos (
	id int not null primary key identity(1,1),
	idCliente INT NOT NULL,
    fechaCreacion DATETIME NOT NULL,
    FOREIGN KEY (idCliente) REFERENCES Clientes(id),
);