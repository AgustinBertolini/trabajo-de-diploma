CREATE TABLE Roles (
	id int not null primary key identity(1,1),
	nombre nvarchar(50) not null
);
GO

INSERT INTO Roles(nombre) VALUES('ADMIN');
INSERT INTO Roles(nombre) VALUES('VENDEDOR');