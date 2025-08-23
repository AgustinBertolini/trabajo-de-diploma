CREATE OR ALTER PROCEDURE InsertDigitoVerificadorHorizontal
    @DV NVARCHAR(MAX),
    @Id INT
AS
BEGIN
  UPDATE usuarios SET DV = @DV WHERE Id = @Id
END;