create proc sp_checkLogin
(
	@user nvarchar(36),
	@password nvarchar(36)

)

as 

begin
	select AccID,is_admin from Account where username= @user and pass = @password
end
DROP PROCEDURE sp_checkLogin

CREATE PROC sp_checkRegistry
(
	@user nvarchar(36)
)

AS 

BEGIN
	SELECT AccID FROM dbo.Account WHERE username=@user
end
