CREATE TABLE Conversaciones_Mensajes (
	id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	idConversacion INT NOT NULL,
	idEmisor INT NOT NULL,
	mensaje NVARCHAR(MAX) NOT NULL,
	fechaEnvio DATETIME NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (idConversacion) REFERENCES Conversaciones(id),
	FOREIGN KEY (idEmisor) REFERENCES Usuarios(id)
);