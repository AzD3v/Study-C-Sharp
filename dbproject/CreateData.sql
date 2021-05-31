CREATE TABLE [dbo].[Team] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
 
CREATE TABLE [dbo].[Player] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
 
CREATE TABLE [dbo].[TeamPlayer] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [TeamId]    INT NOT NULL,
    [PlayerId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [PlayerFK] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Player] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [TeamFK] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id]) ON DELETE CASCADE
);