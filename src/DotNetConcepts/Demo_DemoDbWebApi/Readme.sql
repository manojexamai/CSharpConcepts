/***************
	Runing Entity Framework (EF) Migrations:
	1. View > Other Windows > Package Manager Console
	2. > add-migration "<label>"
	3. > update-database
*******/

---- SQL (Structured Query Language
---- T/SQL Transact SQL

/****
	Relationship models:
	MASTER to TRANSACTION (1 to many)
	TRANSACTION to MASTER (many to one)
****/


/**** MASTER TABLE *****/ 
CREATE TABLE [dbo].[Categories]
(
	[CategoryId] int IDENTITY(101, 1)
	, [CategoryName] nvarchar(50) NOT NULL										-- NVARCHAR encoding is enabled
		CONSTRAINT [CONST_Categories_CategoryName] UNIQUE ( [CategoryName] )

	, CONSTRAINT [PK_Categories] PRIMARY KEY ( [CategoryId] desc )
)
GO

/**** Transaction Table *****/
CREATE TABLE [dbo].[Products]
(
	[ProductId] uniqueidentifier NOT NULL 
		DEFAULT ( newid() )
	, [CId] int NOT NULL											-- foreign key column
	, [ProductName] varchar(100) NOT NULL							-- VACHAR does not support encoding
	, [Description] varchar(MAX) NULL
	, [AddedOn] datetimeoffset NOT NULL								-- datetimeoffset vs. datetime
		DEFAULT ( getdate() )
	, [Quantity] int NOT NULL 
		DEFAULT ( 0 )
	, [IsAvailable] bit NOT NULL 
		DEFAULT ( 0 )													-- 0 is FALSE, 1 is TRUE


	, CONSTRAINT [PK_Products] 
		PRIMARY KEY ( [ProductId] )
	, CONSTRAINT [FK_Products_Category_CId] 
		FOREIGN KEY ( [CId] ) REFERENCES [Category] ( [CategoryId] ) 
)
GO