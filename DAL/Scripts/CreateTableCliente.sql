CREATE TABLE Cliente (
    id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    nombre NVARCHAR(50) NOT NULL,
    apellido NVARCHAR(50) NOT NULL,
    cuit NVARCHAR(50) NOT NULL,
    email NVARCHAR(50) NOT NULL,
    direccion NVARCHAR(100) NOT NULL,
    tipoClienteId INT NOT NULL,
    FOREIGN KEY (tipoClienteId) REFERENCES TipoCliente(id)
)
