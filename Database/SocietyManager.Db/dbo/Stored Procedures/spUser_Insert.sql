CREATE PROCEDURE [dbo].[spUser_Insert]   
	@firstName varchar(50),
	@lastName varchar(50),
	@emailAddress varchar(256),
	@password varchar(max),
	@userName varchar(15),
	@UserId int output
	
	
AS
begin 
set nocount on;
insert into dbo.Users(FirstName,LastName,EmailAddress,this.Password,UserName,Active,IsConfirmed,CreatedDate)
values (@firstName,@lastName,@emailAddress,@password,@userName,1,0,GetDate());
Select @UserId = SCOPE_IDENTITY()

end
