CREATE TABLE [dbo].[TableOrder]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[RestaurantId] INT NOT NULL, 
	[TableNumber] INT NOT NULL,
	[TableOwner] UNIQUEIDENTIFIER NOT NULL, 
	[ClosedOrder] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_TableOrder_RestaurantTable] FOREIGN KEY ([RestaurantId], [TableNumber]) REFERENCES [RestaurantTable]([RestaurantId], [TableNumber]), 
    CONSTRAINT [FK_TableOrder_User] FOREIGN KEY ([TableOwner]) REFERENCES [User]([Id])
)
