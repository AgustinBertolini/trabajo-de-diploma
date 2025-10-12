CREATE TABLE PresupuestoItem (
	id int not null primary key identity(1,1),
	idPresupuesto INT NOT NULL,
    idProducto INT NOT NULL,
    cantidad INT NOT NULL,
    precioUnitario decimal(18,2) NOT NULL,
    FOREIGN KEY (idPresupuesto) REFERENCES Presupuestos(id),
    FOREIGN KEY (idProducto) REFERENCES Productos(id),
);