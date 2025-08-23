CREATE OR ALTER PROCEDURE DeleteIdioma
	@Id int
AS
BEGIN
	DELETE th
	FROM traducciones_historico th
	INNER JOIN Traducciones t ON t.id = th.idTraduccion
	WHERE t.idIdioma = @Id;

    DELETE FROM Traducciones WHERE idIdioma = @Id;

	DELETE FROM Idiomas WHERE id = @Id;
END;