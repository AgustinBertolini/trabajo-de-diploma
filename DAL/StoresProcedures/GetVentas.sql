CREATE OR ALTER PROCEDURE GetVentas
AS
BEGIN
    SELECT v.*,e.nombre as estadoEnvio FROM Ventas v inner join envios e on e.id = v.idEnvio
END;