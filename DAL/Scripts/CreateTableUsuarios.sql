CREATE TABLE Usuarios (
	id int not null primary key identity(1,1),
	nombre nvarchar(50) not null,
	apellido nvarchar(50) not null,
	dni bigint not null,
	email nvarchar(100) not null unique,
	contraseña nvarchar(255) not null,
	isActive bit not null,
	rolId int not null default(1),
	FOREIGN KEY (rolId) REFERENCES roles(id)
);