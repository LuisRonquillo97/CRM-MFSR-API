USE [CrmMfsr]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
/*
 * Seeds for permissions to SQL Server
*/

--Users module. Consider "User.See" and "User.Create" are created on code.
INSERT INTO [Permissions] (Id,[Key], [Name], [Description], IsActive,CreatedAt,CreatedBy)
VALUES (NEWID(), 'User.Update', 'Update users', 'Update users', 1, GETDATE(), 'mainSeed'),
(NEWID(), 'User.Delete', 'Delete users', 'Delete users', 1, GETDATE(), 'mainSeed');
--Roles module.
INSERT INTO [Permissions] (Id,[Key], [Name], [Description], IsActive,CreatedAt,CreatedBy)
VALUES
(NEWID(), 'Role.Update', 'Update roles', 'Update roles', 1, GETDATE(), 'mainSeed'),
(NEWID(), 'Role.Create', 'Create roles', 'Create roles', 1, GETDATE(), 'mainSeed'),
(NEWID(), 'Role.See', 'See roles', 'See roles', 1, GETDATE(), 'mainSeed'),
(NEWID(), 'Role.Delete', 'Delete roles', 'Delete roles', 1, GETDATE(), 'mainSeed');