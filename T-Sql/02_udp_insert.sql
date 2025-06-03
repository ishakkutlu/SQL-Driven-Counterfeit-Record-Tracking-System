--------------------------------------------------
-- [INSERT] Add new counterfeit record
--------------------------------------------------
ALTER PROCEDURE [dbo].[udp_Sahtecilik_Ekle] 
(
	@Rapor_Kodu int,
	@Tespit nchar(10),
	@Banknot_Cinsi nchar(20),
	@Banknot_Adedi int,
	@Nominal_Deger int,
	@Seri_Sira_No varchar(20),
	@Rapor_Tarihi date
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION TR01;
		SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

		IF @Rapor_Kodu<1
			RAISERROR ('Rapor kodu girilmemiş.', 16,10);
		IF (EXISTS(SELECT TOP 1 * FROM Sahtecilik_Raporu WHERE Rapor_Kodu=@Rapor_Kodu))
			RAISERROR ('Bu koda sahip rapor daha önce oluşturulmuş.', 16,10);
		IF ((@Tespit IS NULL) OR (LEN(LTRIM(RTRIM(@Tespit)))<1))
			RAISERROR ('Tespit bilgisi girilmemiş.', 16,10);
		IF ((@Banknot_Cinsi IS NULL) OR (LEN(LTRIM(RTRIM(@Banknot_Cinsi)))<1))
			RAISERROR ('Banknot cinsi girilmemiş.', 16,10);
		IF @Banknot_Adedi<1
			RAISERROR ('Banknot adedi girilmemiş.', 16,10);
		IF @Nominal_Deger<1
			RAISERROR ('Nominal değer girilmemiş.', 16,10);
		IF ((@Seri_Sira_No IS NULL) OR (LEN(LTRIM(RTRIM(@Seri_Sira_No)))<1))
			RAISERROR ('Seri-sıra no girilmemiş.', 16,10);
		IF ((@Rapor_Tarihi IS NULL) OR (@Rapor_Tarihi = '1900-01-01'))
			RAISERROR ('Rapor tarihi girilmemiş.', 16,10);

		INSERT INTO Sahtecilik_Raporu (Rapor_Kodu, Tespit, Banknot_Cinsi, Banknot_Adedi, Nominal_Deger, Seri_Sira_No, Rapor_Tarihi)
		VALUES (@Rapor_Kodu, @Tespit, @Banknot_Cinsi, @Banknot_Adedi, @Nominal_Deger,@Seri_Sira_No, @Rapor_Tarihi);

		COMMIT TRANSACTION TR01;
		SELECT 0 AS Sonuc, 'İşlem başarılı bir şekilde kaydedildi.' AS Mesaj;
	END TRY
	BEGIN CATCH
		IF (@@TRANCOUNT>0) ROLLBACK TRANSACTION TR01;
		SELECT 1 AS Sonuc, ERROR_MESSAGE() AS Mesaj;
	END CATCH
END