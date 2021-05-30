drop table dbo.TeamPlayer
drop table dbo.Team
drop table dbo.Player
 
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
    CONSTRAINT [PlayerFK] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Animal] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [TeamFK] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Zoo] ([Id]) ON DELETE CASCADE
);
 
insert into dbo.Zoo values ('New York')
insert into dbo.Zoo values ('Tokyo')
insert into dbo.Zoo values ('Berlin')
insert into dbo.Zoo values ('Kairo')
insert into dbo.Zoo values ('Milan')
 
insert into dbo.Animal values ('Shark')
insert into dbo.Animal values ('Clownfish')
insert into dbo.Animal values ('Monkey')
insert into dbo.Animal values ('Wolf')
insert into dbo.Animal values ('Gecko')
insert into dbo.Animal values ('Crocodile')
insert into dbo.Animal values ('Owl')
insert into dbo.Animal values ('Parrot')
 
insert into dbo.ZooAnimal values (1,1)
insert into dbo.ZooAnimal values (1,2)
insert into dbo.ZooAnimal values (2,3)
insert into dbo.ZooAnimal values (2,4)
insert into dbo.ZooAnimal values (3,5)
insert into dbo.ZooAnimal values (3,6)
insert into dbo.ZooAnimal values (4,7)
insert into dbo.ZooAnimal values (4,8)
insert into dbo.ZooAnimal values (5, 1)
insert into dbo.ZooAnimal values (5, 2)
insert into dbo.ZooAnimal values (5, 3)
insert into dbo.ZooAnimal values (5, 4)
insert into dbo.ZooAnimal values (5, 5)
insert into dbo.ZooAnimal values (5, 6)
insert into dbo.ZooAnimal values (5, 7)
insert into dbo.ZooAnimal values (5, 8)
 