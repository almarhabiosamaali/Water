-- =============================================
-- Stored Procedure: period_reverse_downtime
-- إلغاء التعديلات التي تمت على الفترة بسبب التوقف
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[period_reverse_downtime]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[period_reverse_downtime]
GO

CREATE PROCEDURE [dbo].[period_reverse_downtime]
    @period_id VARCHAR(50),
    @downtime_id VARCHAR(50) = NULL,
    @removed_days INT = 0,
    @removed_hours INT = 0,
    @removed_minutes INT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        DECLARE @current_start_date DATETIME;
        DECLARE @current_end_date DATETIME;
        DECLARE @current_downtime_hours VARCHAR(50);
        DECLARE @current_extended_days INT;
        DECLARE @current_total_hours INT;
        DECLARE @new_extended_days INT;
        DECLARE @new_total_hours INT;
        DECLARE @new_downtime_hours VARCHAR(50);
        DECLARE @new_end_date DATETIME;
        DECLARE @total_minutes_to_remove INT;
        
        IF NOT EXISTS (SELECT 1 FROM periods WHERE id = @period_id)
        BEGIN
            RAISERROR('الفترة غير موجودة', 16, 1);
            RETURN;
        END
        
        SELECT 
            @current_start_date = start_date,
            @current_end_date = end_date,
            @current_downtime_hours = ISNULL(downtime_hours, ''),
            @current_extended_days = ISNULL(extended_days, 0),
            @current_total_hours = ISNULL(total_hours, 0)
        FROM periods
        WHERE id = @period_id;
        
        SET @new_extended_days = @current_extended_days - @removed_days;
        IF @new_extended_days < 0
        BEGIN
            SET @new_extended_days = 0;
        END
        
        SET @new_total_hours = @current_total_hours - (@removed_days * 20) - @removed_hours;
        IF @new_total_hours < 0
        BEGIN
            SET @new_total_hours = 0;
        END
        
        SET @total_minutes_to_remove = (@removed_days * 24 * 60) + (@removed_hours * 60) + @removed_minutes;
        
        SET @new_end_date = @current_end_date;
        SET @new_end_date = DATEADD(DAY, -@removed_days, @new_end_date);
        SET @new_end_date = DATEADD(HOUR, -@removed_hours, @new_end_date);
        SET @new_end_date = DATEADD(MINUTE, -@removed_minutes, @new_end_date);
        
        IF @new_end_date < @current_start_date
        BEGIN
            SET @new_end_date = @current_start_date;
        END
        
        SET @new_downtime_hours = '';
        IF @new_extended_days > 0
        BEGIN
            SET @new_downtime_hours = CAST(@new_extended_days AS VARCHAR) + ' days';
        END
        
        IF @new_total_hours > (@new_extended_days * 20)
        BEGIN
            DECLARE @remaining_hours INT = @new_total_hours - (@new_extended_days * 20);
            IF @remaining_hours > 0
            BEGIN
                IF LEN(@new_downtime_hours) > 0
                BEGIN
                    SET @new_downtime_hours = @new_downtime_hours + ', ';
                END
                SET @new_downtime_hours = @new_downtime_hours + CAST(@remaining_hours AS VARCHAR) + ' hours';
            END
        END
        
        IF LEN(@new_downtime_hours) = 0
        BEGIN
            SET @new_downtime_hours = NULL;
        END
        
        UPDATE periods
        SET 
            end_date = @new_end_date,
            extended_days = @new_extended_days,
            downtime_hours = @new_downtime_hours,
            total_hours = @new_total_hours
        WHERE id = @period_id;
        
        UPDATE periods
        SET 
            start_date = DATEADD(MINUTE, -@total_minutes_to_remove, start_date),
            end_date = DATEADD(MINUTE, -@total_minutes_to_remove, end_date)
        WHERE start_date > @current_end_date;
        
        DELETE FROM period_adjustments
        WHERE downtime_id = @downtime_id AND period_id = @period_id;
        
        COMMIT TRANSACTION;
        
        SELECT 1 AS Success, 'تم إلغاء التعديلات من الفترة بنجاح' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;
        
        SET @ErrorMessage = ERROR_MESSAGE();
        SET @ErrorSeverity = ERROR_SEVERITY();
        SET @ErrorState = ERROR_STATE();
        
        SELECT 0 AS Success, @ErrorMessage AS Message;
        
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO

