--------------------------------------------------
-- [DELETE] Remove a record by Rapor_Kodu
--------------------------------------------------

ALTER PROCEDURE udp_Sahtecilik_Sil
(
    @Rapor_Kodu int
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION TR01;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

        IF NOT EXISTS (SELECT 1 FROM Sahtecilik_Raporu WHERE Rapor_Kodu = @Rapor_Kodu)
            RAISERROR ('Silinecek kayıt bulunamadı.', 16, 10);

        DELETE FROM Sahtecilik_Raporu WHERE Rapor_Kodu = @Rapor_Kodu;

        COMMIT TRANSACTION TR01;
	SELECT 0 AS Sonuc, CONCAT('Rapor kodu ', @Rapor_Kodu, ' olan kayıt veri tabanından başarılı bir şekilde silindi.') AS Mesaj;

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION TR01;
        SELECT 1 AS Sonuc, ERROR_MESSAGE() AS Mesaj;
    END CATCH
END