CREATE OR ALTER PROCEDURE GetVentaById
  @Id int
AS
BEGIN
    SELECT v.*,e.nombre as estadoEnvio FROM Ventas v inner join envios e on e.id = v.idenvio WHERE v.id = @Id
END;