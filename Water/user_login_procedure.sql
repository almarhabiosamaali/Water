-- Stored Procedure للتحقق من تسجيل الدخول
-- يجب تنفيذ هذا السكريبت في قاعدة البيانات

CREATE PROCEDURE [dbo].[user_login]
    @SignInName VARCHAR(50),
    @PWD VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        [ID],
        [SignInName],
        [FullName],
        [UserType],
        [PWD]
    FROM [Users]
    WHERE [SignInName] = @SignInName 
      AND [PWD] = @PWD;
END
GO

