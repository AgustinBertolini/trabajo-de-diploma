CREATE TABLE Traducciones (
	id int not null primary key identity(1,1),
	idIdioma INT NOT NULL,
    idTag INT NOT NULL,
    traduccion nvarchar(100),
    FOREIGN KEY (idIdioma) REFERENCES Idiomas(id),
    FOREIGN KEY (idTag) REFERENCES Tags(id),
);