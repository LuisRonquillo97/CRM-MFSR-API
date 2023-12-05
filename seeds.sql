USE [CrmMfsr]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
/*
 * Seeds for permissions to SQL Server
*/
--Variables to get admin id, and admin role id, created from code seeds.
DECLARE @adminId UNIQUEIDENTIFIER, 
@roleId UNIQUEIDENTIFIER,
@defaultCreatedBy VARCHAR(250) = 'seedQuery';

--Get admin seed user and role, used to add role administrator to admin user.
select @adminId = ID FROM Users WHERE Email = 'admin@mail.com';
select @roleId = ID FROM Roles WHERE [Name] = 'Administrator';

BEGIN TRANSACTION;
BEGIN TRY
	--Add admin user to admin role.
	DELETE FROM UserRoles WHERE UserId = @adminId;
	INSERT INTO UserRoles (Id,RoleId,UserId, IsActive, CreatedAt, CreatedBy)
	VALUES(NEWID(), @roleId, @adminId, 1, GETDATE(), @defaultCreatedBy);

	--Users module. Consider "User.See" and "User.Create" are created on code.

	INSERT INTO [Permissions] (Id,[Key], [Name], [Description], IsActive, CreatedAt, CreatedBy)
	VALUES (NEWID(), 'User.Update', 'Update users', 'Update users', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'User.Delete', 'Delete users', 'Delete users', 1, GETDATE(), @defaultCreatedBy);

	--Roles module.
	INSERT INTO [Permissions] (Id,[Key], [Name], [Description], IsActive, CreatedAt, CreatedBy)
	VALUES
	(NEWID(), 'Role.Update', 'Update roles', 'Update roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Role.Create', 'Create roles', 'Create roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Role.See', 'See roles', 'See roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Role.Delete', 'Delete roles', 'Delete roles', 1, GETDATE(), @defaultCreatedBy);

	--Development module.
	INSERT INTO [Permissions] (Id,[Key], [Name], [Description], IsActive, CreatedAt, CreatedBy)
	VALUES
	(NEWID(), 'Development.Update', 'Update roles', 'Update roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Development.Create', 'Create roles', 'Create roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Development.See', 'See roles', 'See roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Development.Delete', 'Delete roles', 'Delete roles', 1, GETDATE(), @defaultCreatedBy);

	--Stage module.
	INSERT INTO [Permissions] (Id,[Key], [Name], [Description], IsActive, CreatedAt, CreatedBy)
	VALUES
	(NEWID(), 'Stage.Update', 'Update roles', 'Update roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Stage.Create', 'Create roles', 'Create roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Stage.See', 'See roles', 'See roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Stage.Delete', 'Delete roles', 'Delete roles', 1, GETDATE(), @defaultCreatedBy);

	--Lot module.
	INSERT INTO [Permissions] (Id,[Key], [Name], [Description], IsActive, CreatedAt, CreatedBy)
	VALUES
	(NEWID(), 'Lot.Update', 'Update roles', 'Update roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Lot.Create', 'Create roles', 'Create roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Lot.See', 'See roles', 'See roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'Lot.Delete', 'Delete roles', 'Delete roles', 1, GETDATE(), @defaultCreatedBy);

	--LotCategory module.
	INSERT INTO [Permissions] (Id,[Key], [Name], [Description], IsActive, CreatedAt, CreatedBy)
	VALUES
	(NEWID(), 'LotCategory.Update', 'Update roles', 'Update roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'LotCategory.Create', 'Create roles', 'Create roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'LotCategory.See', 'See roles', 'See roles', 1, GETDATE(), @defaultCreatedBy),
	(NEWID(), 'LotCategory.Delete', 'Delete roles', 'Delete roles', 1, GETDATE(), @defaultCreatedBy);


	--Added all permissionns to admin role.
	DELETE FROM RolePermissions WHERE RoleId = @roleId;
	INSERT INTO RolePermissions (Id,PermissionId,RoleId, IsActive, CreatedAt, CreatedBy)
	SELECT NEWID(), P.Id, @roleId, 1, GETDATE(), @defaultCreatedBy
	FROM [Permissions] P
	print('transaction committed.');
	COMMIT TRANSACTION;
END TRY 
BEGIN CATCH 
	print('transaction rollbacked.');
	PRINT N'Error Mensage = ' + ERROR_MESSAGE()
	PRINT N'Error Number = ' + CAST(ERROR_NUMBER() AS VARCHAR)
	PRINT N'Error Line = ' + CAST(ERROR_LINE() AS VARCHAR)
	PRINT N'Error Severity = ' + CAST(ERROR_SEVERITY() AS VARCHAR)
	PRINT N'Error State = ' + CAST(ERROR_STATE() AS VARCHAR)
	ROLLBACK TRANSACTION;
END CATCH

