CREATE TABLE [dbo].[Person] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (100) NULL,
    [Age]  INT           NULL,
    CONSTRAINT [PK_Person_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

