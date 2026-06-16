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
    [TeamRole] nvarchar(max) NULL,
    [SeniorityLevel] int NULL,
    [Field] int NULL,
    [Type] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Projects] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Description] nvarchar(300) NOT NULL,
    [Status] int NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [EmployeeProject] (
    [MembersId] int NOT NULL,
    [ProjectsId] int NOT NULL,
    CONSTRAINT [PK_EmployeeProject] PRIMARY KEY ([MembersId], [ProjectsId]),
    CONSTRAINT [FK_EmployeeProject_Employees_MembersId] FOREIGN KEY ([MembersId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeProject_Projects_ProjectsId] FOREIGN KEY ([ProjectsId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Sprints] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Goal] nvarchar(500) NULL,
    [ProjectId] int NOT NULL,
    [ScrumMasterId] int NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NULL,
    [EstimatedWorkHours] int NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Sprints] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Sprints_Employees_ScrumMasterId] FOREIGN KEY ([ScrumMasterId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Sprints_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [UserStories] (
    [Id] int NOT NULL IDENTITY,
    [ProjectId] int NOT NULL,
    [Title] nvarchar(100) NOT NULL,
    [Description] nvarchar(500) NOT NULL,
    [Priority] int NOT NULL,
    CONSTRAINT [PK_UserStories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserStories_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [WorkTasks] (
    [Id] int NOT NULL IDENTITY,
    [UserStoryId] int NOT NULL,
    [SprintId] int NULL,
    [Name] nvarchar(150) NOT NULL,
    [Description] nvarchar(600) NOT NULL,
    [Status] int NOT NULL,
    [EstimatedHours] decimal(6,2) NOT NULL,
    CONSTRAINT [PK_WorkTasks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WorkTasks_Sprints_SprintId] FOREIGN KEY ([SprintId]) REFERENCES [Sprints] ([Id]),
    CONSTRAINT [FK_WorkTasks_UserStories_UserStoryId] FOREIGN KEY ([UserStoryId]) REFERENCES [UserStories] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Employee_AssignedTo_WorkTask] (
    [AssignedEmployeesId] int NOT NULL,
    [AssignedTasksId] int NOT NULL,
    CONSTRAINT [PK_Employee_AssignedTo_WorkTask] PRIMARY KEY ([AssignedEmployeesId], [AssignedTasksId]),
    CONSTRAINT [FK_Employee_AssignedTo_WorkTask_Employees_AssignedEmployeesId] FOREIGN KEY ([AssignedEmployeesId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Employee_AssignedTo_WorkTask_WorkTasks_AssignedTasksId] FOREIGN KEY ([AssignedTasksId]) REFERENCES [WorkTasks] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [WorkTaskEntries] (
    [Id] int NOT NULL IDENTITY,
    [EmployeeId] int NOT NULL,
    [WorkTaskId] int NOT NULL,
    [WorkDate] datetime2 NOT NULL,
    [HoursWorked] decimal(6,2) NOT NULL,
    CONSTRAINT [PK_WorkTaskEntries] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WorkTaskEntries_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_WorkTaskEntries_WorkTasks_WorkTaskId] FOREIGN KEY ([WorkTaskId]) REFERENCES [WorkTasks] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Employee_AssignedTo_WorkTask_AssignedTasksId] ON [Employee_AssignedTo_WorkTask] ([AssignedTasksId]);
GO


CREATE INDEX [IX_EmployeeProject_ProjectsId] ON [EmployeeProject] ([ProjectsId]);
GO


CREATE UNIQUE INDEX [IX_Employees_Email] ON [Employees] ([Email]);
GO


CREATE UNIQUE INDEX [IX_Employees_Username] ON [Employees] ([Username]);
GO


CREATE INDEX [IX_Sprints_ProjectId] ON [Sprints] ([ProjectId]);
GO


CREATE INDEX [IX_Sprints_ScrumMasterId] ON [Sprints] ([ScrumMasterId]);
GO


CREATE INDEX [IX_UserStories_ProjectId] ON [UserStories] ([ProjectId]);
GO


CREATE INDEX [IX_WorkTaskEntries_EmployeeId] ON [WorkTaskEntries] ([EmployeeId]);
GO


CREATE INDEX [IX_WorkTaskEntries_WorkTaskId] ON [WorkTaskEntries] ([WorkTaskId]);
GO


CREATE INDEX [IX_WorkTasks_SprintId] ON [WorkTasks] ([SprintId]);
GO


CREATE INDEX [IX_WorkTasks_UserStoryId] ON [WorkTasks] ([UserStoryId]);
GO


