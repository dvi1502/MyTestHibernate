CREATE TABLE [dbo].[Cat]
(
	[Id] int NOT NULL PRIMARY KEY identity(1,1),
	[Name] nvarchar(16) NOT NULL,
	[Sex] nchar(1),
	[Weight] real
)
