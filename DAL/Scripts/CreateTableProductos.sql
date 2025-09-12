CREATE TABLE Productos (
	id int not null primary key identity(1,1),
	nombre nvarchar(50) not null,
	precio int not null,
	stock int not null,
	active bit not null,
	fechaCreacion datetime not null,
	fechaActualizacion datetime not null
);

