CREATE TABLE [dbo].[Users]
(
  	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(256) NOT NULL,     
    [Password] VARCHAR(MAX) NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [IsConfirmed] BIT NOT NULL DEFAULT 0, 
    [CreatedDate] DATETIME NOT NULL DEFAULT getutcdate(), 
    [VerificationData] VARCHAR(50) NULL, 
    [PasswordChangeGuid] NVARCHAR(50) NULL, 
)
