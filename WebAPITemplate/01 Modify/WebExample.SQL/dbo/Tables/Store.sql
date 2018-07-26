CREATE TABLE [dbo].[Store] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Code] VARCHAR (100) NULL,
    CONSTRAINT [PK_Store_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

