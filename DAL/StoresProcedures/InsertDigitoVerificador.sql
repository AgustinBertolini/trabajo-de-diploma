CREATE OR ALTER PROCEDURE InsertDigitoVerificador
    @DV NVARCHAR(MAX)
AS
BEGIN
   DELETE FROM DigitoVerificador;
   
   INSERT INTO DigitoVerificador(DV) VALUES (@DV);
END;