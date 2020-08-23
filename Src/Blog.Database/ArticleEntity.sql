﻿CREATE TABLE [dbo].[Post]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Subject] NVARCHAR(50) NOT NULL, 
    [Body] NVARCHAR(MAX) NOT NULL, 
    [DateCreated] DATETIME NOT NULL, 
    [Author] INT NOT NULL
)
