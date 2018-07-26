CREATE TABLE [dbo].[Account] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Code]    VARCHAR (100) NULL,
    [OwnerId] INT           NULL,
    CONSTRAINT [PK_Account_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Account_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[Person] ([Id])
);

