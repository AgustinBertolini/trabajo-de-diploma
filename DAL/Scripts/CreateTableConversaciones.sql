CREATE TABLE Conversaciones (
	id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	idUsuario INT NOT NULL,
	FOREIGN KEY (idUsuario) REFERENCES Usuarios(id),
);