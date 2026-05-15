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
CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    [Role] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260421173122_InitialCreate', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260421184829_AddingUser', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
DROP TABLE [Users];

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Email] nvarchar(120) NOT NULL,
    [Phone] nvarchar(30) NULL,
    [HireDate] datetime2 NOT NULL,
    [Status] nvarchar(20) NOT NULL,
    [Username] nvarchar(50) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    [CertificationLevel] nvarchar(max) NULL,
    [ProductDomain] nvarchar(max) NULL,
    [TeamRole] nvarchar(max) NULL,
    [SeniorityLevel] nvarchar(max) NULL,
    [Field] nvarchar(max) NULL,
    [Type] int NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260421185030_AddingEmployees', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
DECLARE @var nvarchar(max);
SELECT @var = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'Type');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT ' + @var + ';');
ALTER TABLE [Employees] ALTER COLUMN [Type] nvarchar(max) NOT NULL;

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [Phone] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);

CREATE TABLE [Distributions] (
    [Id] int NOT NULL IDENTITY,
    [Version] nvarchar(30) NOT NULL,
    [Environment] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Distributions] PRIMARY KEY ([Id])
);

CREATE TABLE [Projects] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Description] nvarchar(300) NOT NULL,
    [Status] nvarchar(30) NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
);

CREATE TABLE [UserStories] (
    [Id] int NOT NULL IDENTITY,
    [ClientId] int NULL,
    [Title] nvarchar(50) NOT NULL,
    [Description] nvarchar(50) NOT NULL,
    [Priority] int NOT NULL,
    [Status] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_UserStories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserStories_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE SET NULL
);

CREATE TABLE [Increments] (
    [Id] int NOT NULL IDENTITY,
    [DistributionId] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [Status] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Increments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Increments_Distributions_DistributionId] FOREIGN KEY ([DistributionId]) REFERENCES [Distributions] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Employee_WorksOn_Project] (
    [MembersId] int NOT NULL,
    [ProjectsId] int NOT NULL,
    CONSTRAINT [PK_Employee_WorksOn_Project] PRIMARY KEY ([MembersId], [ProjectsId]),
    CONSTRAINT [FK_Employee_WorksOn_Project_Employees_MembersId] FOREIGN KEY ([MembersId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Employee_WorksOn_Project_Projects_ProjectsId] FOREIGN KEY ([ProjectsId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Sprints] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [ScrumMasterId] int NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NULL,
    [EstimatedWorkHours] int NOT NULL,
    [Status] nvarchar(30) NOT NULL,
    [DistributionId] int NULL,
    CONSTRAINT [PK_Sprints] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Sprints_Distributions_DistributionId] FOREIGN KEY ([DistributionId]) REFERENCES [Distributions] ([Id]),
    CONSTRAINT [FK_Sprints_Employees_ScrumMasterId] FOREIGN KEY ([ScrumMasterId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Sprints_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Features] (
    [Id] int NOT NULL IDENTITY,
    [SprintId] int NOT NULL,
    [IncrementId] int NOT NULL,
    [Name] nvarchar(150) NOT NULL,
    [Description] nvarchar(600) NOT NULL,
    CONSTRAINT [PK_Features] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Features_Increments_IncrementId] FOREIGN KEY ([IncrementId]) REFERENCES [Increments] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Features_Sprints_SprintId] FOREIGN KEY ([SprintId]) REFERENCES [Sprints] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Meetings] (
    [Id] int NOT NULL IDENTITY,
    [SprintId] int NOT NULL,
    [DateTime] datetime2 NOT NULL,
    [DurationMinutes] int NOT NULL,
    [Description] nvarchar(300) NULL,
    [Type] nvarchar(max) NOT NULL,
    [SprintGoal] nvarchar(300) NULL,
    [Feedback] nvarchar(300) NULL,
    CONSTRAINT [PK_Meetings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Meetings_Sprints_SprintId] FOREIGN KEY ([SprintId]) REFERENCES [Sprints] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [WorkTasks] (
    [Id] int NOT NULL IDENTITY,
    [UserStoryId] int NOT NULL,
    [SprintId] int NOT NULL,
    [Name] nvarchar(150) NOT NULL,
    [Description] nvarchar(600) NOT NULL,
    [Status] nvarchar(30) NOT NULL,
    [EstimatedHours] decimal(6,2) NOT NULL,
    [UserStoryId1] int NULL,
    CONSTRAINT [PK_WorkTasks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WorkTasks_Sprints_SprintId] FOREIGN KEY ([SprintId]) REFERENCES [Sprints] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WorkTasks_UserStories_UserStoryId] FOREIGN KEY ([UserStoryId]) REFERENCES [UserStories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_WorkTasks_UserStories_UserStoryId1] FOREIGN KEY ([UserStoryId1]) REFERENCES [UserStories] ([Id])
);

CREATE TABLE [WorkTaskEntries] (
    [EmployeeId] int NOT NULL,
    [WorkTaskId] int NOT NULL,
    [WorkDate] datetime2 NOT NULL,
    [HoursWorked] decimal(6,2) NOT NULL,
    CONSTRAINT [PK_WorkTaskEntries] PRIMARY KEY ([EmployeeId], [WorkTaskId], [WorkDate]),
    CONSTRAINT [FK_WorkTaskEntries_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_WorkTaskEntries_WorkTasks_WorkTaskId] FOREIGN KEY ([WorkTaskId]) REFERENCES [WorkTasks] ([Id]) ON DELETE CASCADE
);

CREATE UNIQUE INDEX [IX_Employees_Email] ON [Employees] ([Email]);

CREATE UNIQUE INDEX [IX_Employees_Username] ON [Employees] ([Username]);

CREATE UNIQUE INDEX [IX_Clients_Email] ON [Clients] ([Email]);

CREATE INDEX [IX_Employee_WorksOn_Project_ProjectsId] ON [Employee_WorksOn_Project] ([ProjectsId]);

CREATE INDEX [IX_Features_IncrementId] ON [Features] ([IncrementId]);

CREATE INDEX [IX_Features_SprintId] ON [Features] ([SprintId]);

CREATE INDEX [IX_Increments_DistributionId] ON [Increments] ([DistributionId]);

CREATE INDEX [IX_Meetings_SprintId] ON [Meetings] ([SprintId]);

CREATE INDEX [IX_Sprints_DistributionId] ON [Sprints] ([DistributionId]);

CREATE INDEX [IX_Sprints_ProjectId] ON [Sprints] ([ProjectId]);

CREATE INDEX [IX_Sprints_ScrumMasterId] ON [Sprints] ([ScrumMasterId]);

CREATE INDEX [IX_UserStories_ClientId] ON [UserStories] ([ClientId]);

CREATE INDEX [IX_WorkTaskEntries_WorkTaskId] ON [WorkTaskEntries] ([WorkTaskId]);

CREATE INDEX [IX_WorkTasks_SprintId] ON [WorkTasks] ([SprintId]);

CREATE INDEX [IX_WorkTasks_UserStoryId] ON [WorkTasks] ([UserStoryId]);

CREATE INDEX [IX_WorkTasks_UserStoryId1] ON [WorkTasks] ([UserStoryId1]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260421190504_AddedAllToDatabase', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
DECLARE @var1 nvarchar(max);
SELECT @var1 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Meetings]') AND [c].[name] = N'SprintGoal');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Meetings] DROP CONSTRAINT ' + @var1 + ';');
ALTER TABLE [Meetings] ALTER COLUMN [SprintGoal] nvarchar(max) NULL;

DECLARE @var2 nvarchar(max);
SELECT @var2 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Meetings]') AND [c].[name] = N'Feedback');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Meetings] DROP CONSTRAINT ' + @var2 + ';');
ALTER TABLE [Meetings] ALTER COLUMN [Feedback] nvarchar(max) NULL;

CREATE TABLE [Employee_Attends_Meeting] (
    [AttendeesId] int NOT NULL,
    [MeetingsId] int NOT NULL,
    CONSTRAINT [PK_Employee_Attends_Meeting] PRIMARY KEY ([AttendeesId], [MeetingsId]),
    CONSTRAINT [FK_Employee_Attends_Meeting_Employees_AttendeesId] FOREIGN KEY ([AttendeesId]) REFERENCES [Employees] ([Id]),
    CONSTRAINT [FK_Employee_Attends_Meeting_Meetings_MeetingsId] FOREIGN KEY ([MeetingsId]) REFERENCES [Meetings] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Employee_Attends_Meeting_MeetingsId] ON [Employee_Attends_Meeting] ([MeetingsId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260421192137_DatabaseDoneNow', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
DECLARE @var3 nvarchar(max);
SELECT @var3 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'CertificationLevel');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT ' + @var3 + ';');
ALTER TABLE [Employees] DROP COLUMN [CertificationLevel];

DECLARE @var4 nvarchar(max);
SELECT @var4 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'ProductDomain');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT ' + @var4 + ';');
ALTER TABLE [Employees] DROP COLUMN [ProductDomain];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260422200801_RemovedShitFromEmployee', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
DECLARE @var5 nvarchar(max);
SELECT @var5 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'SeniorityLevel');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT ' + @var5 + ';');
ALTER TABLE [Employees] ALTER COLUMN [SeniorityLevel] int NULL;

DECLARE @var6 nvarchar(max);
SELECT @var6 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'Field');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT ' + @var6 + ';');
ALTER TABLE [Employees] ALTER COLUMN [Field] int NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260423001159_AddedNewEnums', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
DECLARE @var7 nvarchar(max);
SELECT @var7 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'Status');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT ' + @var7 + ';');
ALTER TABLE [Projects] ALTER COLUMN [Status] int NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260423025013_AddedNewEnumsToProject', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
DECLARE @var8 nvarchar(max);
SELECT @var8 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sprints]') AND [c].[name] = N'Status');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Sprints] DROP CONSTRAINT ' + @var8 + ';');
ALTER TABLE [Sprints] ALTER COLUMN [Status] nvarchar(max) NOT NULL;

DECLARE @var9 nvarchar(max);
SELECT @var9 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sprints]') AND [c].[name] = N'ScrumMasterId');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Sprints] DROP CONSTRAINT ' + @var9 + ';');
ALTER TABLE [Sprints] ALTER COLUMN [ScrumMasterId] int NULL;

ALTER TABLE [Sprints] ADD [Goal] nvarchar(500) NULL;

ALTER TABLE [Sprints] ADD [Name] nvarchar(100) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260423233008_NewThingsAndStuffs', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
DECLARE @var10 nvarchar(max);
SELECT @var10 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserStories]') AND [c].[name] = N'Title');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [UserStories] DROP CONSTRAINT ' + @var10 + ';');
ALTER TABLE [UserStories] ALTER COLUMN [Title] nvarchar(100) NOT NULL;

DECLARE @var11 nvarchar(max);
SELECT @var11 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserStories]') AND [c].[name] = N'Status');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [UserStories] DROP CONSTRAINT ' + @var11 + ';');
ALTER TABLE [UserStories] ALTER COLUMN [Status] int NOT NULL;

DECLARE @var12 nvarchar(max);
SELECT @var12 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserStories]') AND [c].[name] = N'Description');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [UserStories] DROP CONSTRAINT ' + @var12 + ';');
ALTER TABLE [UserStories] ALTER COLUMN [Description] nvarchar(500) NOT NULL;

ALTER TABLE [UserStories] ADD [ProjectId] int NOT NULL DEFAULT 0;

ALTER TABLE [UserStories] ADD [SprintId] int NULL;

CREATE INDEX [IX_UserStories_ProjectId] ON [UserStories] ([ProjectId]);

CREATE INDEX [IX_UserStories_SprintId] ON [UserStories] ([SprintId]);

ALTER TABLE [UserStories] ADD CONSTRAINT [FK_UserStories_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE;

ALTER TABLE [UserStories] ADD CONSTRAINT [FK_UserStories_Sprints_SprintId] FOREIGN KEY ([SprintId]) REFERENCES [Sprints] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260425114418_ConnectingUserStoryToProjectsAndSprints', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260512230557_TestingToSeeIfItWillFollowTheNewFolderStructure', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
DECLARE @var13 nvarchar(max);
SELECT @var13 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WorkTasks]') AND [c].[name] = N'Status');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [WorkTasks] DROP CONSTRAINT ' + @var13 + ';');
ALTER TABLE [WorkTasks] ALTER COLUMN [Status] int NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260512230718_NewEnumForWorkTask', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
ALTER TABLE [UserStories] DROP CONSTRAINT [FK_UserStories_Clients_ClientId];

DROP TABLE [Clients];

DROP INDEX [IX_UserStories_ClientId] ON [UserStories];

DECLARE @var14 nvarchar(max);
SELECT @var14 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserStories]') AND [c].[name] = N'ClientId');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [UserStories] DROP CONSTRAINT ' + @var14 + ';');
ALTER TABLE [UserStories] DROP COLUMN [ClientId];

DECLARE @var15 nvarchar(max);
SELECT @var15 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserStories]') AND [c].[name] = N'Status');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [UserStories] DROP CONSTRAINT ' + @var15 + ';');
ALTER TABLE [UserStories] DROP COLUMN [Status];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260512234857_BigRefactorNoMoreClients', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260515090552_FixedSomeEnums', N'10.0.6');

COMMIT;
GO

BEGIN TRANSACTION;
ALTER TABLE [UserStories] DROP CONSTRAINT [FK_UserStories_Sprints_SprintId];

ALTER TABLE [WorkTasks] DROP CONSTRAINT [FK_WorkTasks_Sprints_SprintId];

DROP INDEX [IX_UserStories_SprintId] ON [UserStories];

DECLARE @var16 nvarchar(max);
SELECT @var16 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserStories]') AND [c].[name] = N'SprintId');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [UserStories] DROP CONSTRAINT ' + @var16 + ';');
ALTER TABLE [UserStories] DROP COLUMN [SprintId];

ALTER TABLE [WorkTasks] ADD CONSTRAINT [FK_WorkTasks_Sprints_SprintId] FOREIGN KEY ([SprintId]) REFERENCES [Sprints] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260515092115_RemovingTheUserStoryToSprintReference', N'10.0.6');

COMMIT;
GO

