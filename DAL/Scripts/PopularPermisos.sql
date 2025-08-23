INSERT INTO Permisos (nombre, es_padre) VALUES ('Usuarios', 1);
INSERT INTO Permisos (nombre, es_padre) VALUES ('Crear Usuario', 0);
INSERT INTO Permisos (nombre, es_padre) VALUES ('Editar Usuario', 0);
INSERT INTO Permisos (nombre, es_padre) VALUES ('Borrar Usuario', 0);
INSERT INTO Permisos (nombre, es_padre) VALUES ('Listar Usuario', 0);

INSERT INTO Permisos_Permisos (idPadre, idHijo) VALUES (1, 2);
INSERT INTO Permisos_Permisos (idPadre, idHijo) VALUES (1, 3);
INSERT INTO Permisos_Permisos (idPadre, idHijo) VALUES (1, 4);
INSERT INTO Permisos_Permisos (idPadre, idHijo) VALUES (1, 5);

INSERT INTO Usuario_Permisos (idUsuario, idPermiso) VALUES (1, 1);