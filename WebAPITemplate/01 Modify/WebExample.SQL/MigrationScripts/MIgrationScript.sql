IF OBJECT_ID('[dbo].[Account]') IS NOT NULL DROP TABLE [dbo].[Account]

IF OBJECT_ID('[dbo].[Person]') IS NOT NULL DROP TABLE [dbo].[Person] 
IF OBJECT_ID('[dbo].[Store]') IS NOT NULL DROP TABLE [dbo].[Store] 

CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Age] [int] NULL,
CONSTRAINT [PK_Person_Id] PRIMARY KEY CLUSTERED (Id ASC)
)

 
 CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](100) NULL,
	[OwnerId] [int] NULL,
	CONSTRAINT [PK_Account_Id] PRIMARY KEY CLUSTERED (Id ASC),
	CONSTRAINT [FK_Account_OwnerId] FOREIGN KEY (OwnerId) REFERENCES Person(Id)
)


 CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](100) NULL,
	CONSTRAINT [PK_Store_Id] PRIMARY KEY CLUSTERED (Id ASC)
)


INSERT INTO [dbo].[Person] VALUES
('Chris', 30)

INSERT INTO [dbo].[Account] VALUES
('Chris Account', 1)

INSERT INTO [dbo].[Store] VALUES
('Macys'),
('Target'),
('Walmart'),
('Trader Joes')

SELECT * FROM [dbo].[Person]
SELECT * FROM [dbo].[Person] WHERE ID = 1
SELECT * FROM [dbo].[Account]
SELECT * FROM [dbo].[Account] WHERE ID = 1
SELECT * FROM [dbo].[Store]



 INSERT INTO [dbo].[Person] (Name, Age)VALUES
('David', 32) 
SELECT Id, Name, Age FROM [dbo].[Person] where Id = SCOPE_IDENTITY()