CREATE TABLE Traducciones_Historico (
    id int identity(1,1) primary key not null,
    fecha datetime not null,
    valorViejo nvarchar(200) not null,
    valorNuevo nvarchar(200) not null,
    idTraduccion INT NOT NULL,
    FOREIGN KEY (idTraduccion) REFERENCES Traducciones(id)
);
