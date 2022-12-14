CREATE TABLE [dbo].[TableOrderItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[TableOrderId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[ProductPrice] FLOAT NOT NULL,
	[ProductQuantity] FLOAT NOT NULL,
	[ItemSum] FLOAT NOT NULL, 
    CONSTRAINT [FK_TableOrderItem_TableOrder] FOREIGN KEY ([TableOrderId]) REFERENCES [TableOrder]([Id]), 
    CONSTRAINT [FK_TableOrderItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
