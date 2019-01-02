CREATE TABLE [dbo].[Users]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [MiddleName] NVARCHAR(50) NULL , 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(50) NOT NULL, 
    [ContactNumber] NVARCHAR(50) NULL, 
    [Username] NVARCHAR(30) NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL, 
    [IsActive] BIT NOT NULL,
    [PasswordNeverExpired] BIT NOT NULL, 
    [PasswordChangedAt] DATETIME NULL, 
    [ForgotPasswordKey] NVARCHAR(MAX) NULL,
	[LockedAt] DATETIME NULL, 
    [CreatedAt] DATETIME NOT NULL, 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [ModifiedAt] DATETIME NOT NULL, 
    [ModifiedBy] NVARCHAR(50) NOT NULL, 
)
GO

CREATE UNIQUE INDEX [UI_Users_Username]  ON [dbo].[Users]([Username])
GO
