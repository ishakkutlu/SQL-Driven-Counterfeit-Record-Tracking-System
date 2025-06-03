--------------------------------------------------
-- [SELECT] Retrieve all counterfeit records
--------------------------------------------------
ALTER PROCEDURE [dbo].[udp_Sahtecilik](
@TestParameter int
)
AS
BEGIN
	SELECT 
	Rapor_Kodu AS [Rapor Kodu],
	Tespit AS [Tespit],
	Banknot_Cinsi AS [Banknot Cinsi],
	Banknot_Adedi AS [Banknot Adedi],
	Nominal_Deger AS [Nominal Değer],
	Seri_Sira_No AS [Seri-Sıra No],
	Rapor_Tarihi AS [Rapor Tarihi]

	FROM Sahtecilik_Raporu ORDER BY Rapor_Kodu;
END