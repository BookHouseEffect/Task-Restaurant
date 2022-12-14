CREATE TABLE [dbo].[RestaurantTable]
(
	[RestaurantId] INT NOT NULL, 
	[TableNumber] INT NOT NULL,
	[HasActiveOrder] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_RestaurantTable_Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurant]([Id]), 
    CONSTRAINT [PK_RestaurantTable] PRIMARY KEY ([RestaurantId], [TableNumber])
)
