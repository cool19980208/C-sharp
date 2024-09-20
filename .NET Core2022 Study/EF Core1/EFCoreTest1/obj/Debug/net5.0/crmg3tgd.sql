BEGIN TRANSACTION;
GO

ALTER TABLE [Authors] ADD [Names] nvarchar(max) NULL;
GO

ALTER TABLE [Authors] ADD [Test] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240918010033_AddNames', N'5.0.4');
GO

COMMIT;
GO

