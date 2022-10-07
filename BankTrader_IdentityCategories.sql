USE tempdb;

IF OBJECT_ID('tempdb.dbo.##BANKTRADES') IS NOT NULL 
   DROP TABLE tempdb.dbo.##BANKTRADES;

--DROP TABLE tempdb..##BANKTRADES;	
CREATE TABLE tempdb..##BANKTRADES(
	[ID] INT IDENTITY,
	[Value] decimal(18,2),
	[ClientSector] nvarchar(150),
	[TradeCategories] nvarchar(150));

INSERT INTO tempdb..##BANKTRADES ([Value], [ClientSector]) VALUES (2000000,'Private');
INSERT INTO tempdb..##BANKTRADES ([Value], [ClientSector]) VALUES (400000, 'Public');
INSERT INTO tempdb..##BANKTRADES ([Value], [ClientSector]) VALUES (500000, 'Public');
INSERT INTO tempdb..##BANKTRADES ([Value], [ClientSector]) VALUES (3000000,'Public');

DECLARE @TradeCategories NVARCHAR(50);
DECLARE @Value DECIMAL(18,2);
DECLARE @ClientSector NVARCHAR(150);
DECLARE @ID INT;

SELECT @ID = max(ID) FROM tempdb..##BANKTRADES;

WHILE (@ID > 0)
BEGIN
	SELECT @ClientSector = ClientSector, @Value = [Value] FROM tempdb..##BANKTRADES WHERE ID = @ID;

	IF (UPPER(@ClientSector) = 'PRIVATE' AND @Value > 1000000)
		SET @TradeCategories = 'HIGHRISK'
	ELSE IF (UPPER(@ClientSector) = 'PUBLIC' AND @Value > 1000000)
		SET @TradeCategories = 'MEDIUMRISK'
	ELSE IF (UPPER(@ClientSector) = 'PUBLIC' AND @Value <= 1000000)
		SET @TradeCategories = 'LOWRISK'

	PRINT @TradeCategories;

	UPDATE tempdb..##BANKTRADES SET
		TradeCategories = @TradeCategories
	WHERE ID = @ID;

	SET @ID = @ID - 1;
END

SELECT * FROM tempdb..##BANKTRADES;

