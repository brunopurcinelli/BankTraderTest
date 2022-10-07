IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Traders] (
    [Id] uniqueidentifier NOT NULL,
    [Value] decimal(18,2) NOT NULL,
    [ClientSector] varchar(150) NOT NULL,
    CONSTRAINT [PK_Traders] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221007200350_Initial', N'6.0.9');
GO

COMMIT;
GO

