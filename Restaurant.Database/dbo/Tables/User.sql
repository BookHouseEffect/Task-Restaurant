CREATE TABLE [dbo].[User]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[DisplayName] NVARCHAR(100) NOT NULL,
	[UserName] NVARCHAR(255) NOT NULL,
	[WorkingAtRestaurantId] INT NOT NULL, 
    CONSTRAINT [FK_User_Restaurant] FOREIGN KEY ([WorkingAtRestaurantId]) REFERENCES [Restaurant]([Id])
)
