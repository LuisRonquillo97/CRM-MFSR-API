using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SQLDB.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("1094bade-087b-4eca-b0c3-c0bc47e52b7a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("742530ea-2432-4bc0-b938-e3f14645a676"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("f7948c9b-bac2-4795-8fab-e66ff1c57d48"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("04e0e210-bd83-40d3-8610-4d671991bbd8"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0d585130-d133-43ba-a726-5604ddaa81de"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("baa6230e-bb80-4952-b156-45e127f1d511"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3fac7eef-44f2-4f7b-bd6b-8f6457248865"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Permissions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "Permissions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "Key", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("335bdf65-8603-47ca-ba68-4c13d84fd23f"), new DateTime(2023, 11, 28, 17, 24, 39, 69, DateTimeKind.Utc).AddTicks(723), "MainSeed", null, null, "See all users for the role Admin.", true, "User.See", null, null, "See users" },
                    { new Guid("fd6017b3-efcf-4a2d-b1f2-4d92c190c4db"), new DateTime(2023, 11, 28, 17, 24, 39, 69, DateTimeKind.Utc).AddTicks(736), "MainSeed", null, null, "Create users.", true, "User.Create", null, null, "Create users" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[] { new Guid("7a140337-39ee-4f01-aa97-160cd718cd26"), new DateTime(2023, 11, 28, 11, 24, 39, 69, DateTimeKind.Local).AddTicks(690), "mainSeed", null, null, "Has full permissions.", true, null, null, "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Email", "FirstName", "IsActive", "LastName", "LastUpdatedAt", "LastUpdatedBy", "Password" },
                values: new object[] { new Guid("9667c42e-e7ee-460e-8253-408e02b934f6"), new DateTime(2023, 11, 28, 11, 24, 39, 69, DateTimeKind.Local).AddTicks(490), "mainSeed", null, null, "admin@mail.com", "First", true, "Admin", null, null, "Password" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("355dd94c-d96d-420b-bb2c-68249ccdf787"), new DateTime(2023, 11, 28, 11, 24, 39, 69, DateTimeKind.Local).AddTicks(762), "", null, null, true, null, null, new Guid("335bdf65-8603-47ca-ba68-4c13d84fd23f"), new Guid("7a140337-39ee-4f01-aa97-160cd718cd26") },
                    { new Guid("e682a05f-51b9-47a6-9629-5d369193c8aa"), new DateTime(2023, 11, 28, 11, 24, 39, 69, DateTimeKind.Local).AddTicks(767), "", null, null, true, null, null, new Guid("fd6017b3-efcf-4a2d-b1f2-4d92c190c4db"), new Guid("7a140337-39ee-4f01-aa97-160cd718cd26") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "RoleId", "UserId" },
                values: new object[] { new Guid("16e7f2f6-13ea-47bf-af08-304844fdad03"), new DateTime(2023, 11, 28, 17, 24, 39, 69, DateTimeKind.Utc).AddTicks(801), "mainSeed", null, null, true, null, null, new Guid("7a140337-39ee-4f01-aa97-160cd718cd26"), new Guid("9667c42e-e7ee-460e-8253-408e02b934f6") });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Key",
                table: "Permissions",
                column: "Key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_Key",
                table: "Permissions");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("355dd94c-d96d-420b-bb2c-68249ccdf787"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e682a05f-51b9-47a6-9629-5d369193c8aa"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("16e7f2f6-13ea-47bf-af08-304844fdad03"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("335bdf65-8603-47ca-ba68-4c13d84fd23f"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("fd6017b3-efcf-4a2d-b1f2-4d92c190c4db"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7a140337-39ee-4f01-aa97-160cd718cd26"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9667c42e-e7ee-460e-8253-408e02b934f6"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "Key", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("04e0e210-bd83-40d3-8610-4d671991bbd8"), new DateTime(2023, 11, 27, 22, 23, 16, 524, DateTimeKind.Utc).AddTicks(7293), "MainSeed", null, null, "See all users for the role Admin.", true, "User.See", null, null, "See users" },
                    { new Guid("0d585130-d133-43ba-a726-5604ddaa81de"), new DateTime(2023, 11, 27, 22, 23, 16, 524, DateTimeKind.Utc).AddTicks(7297), "MainSeed", null, null, "CRUD users. Only for the role Admin.", true, "User.Crud", null, null, "CRUD users" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[] { new Guid("baa6230e-bb80-4952-b156-45e127f1d511"), new DateTime(2023, 11, 27, 16, 23, 16, 524, DateTimeKind.Local).AddTicks(7267), "mainSeed", null, null, "Has full permissions.", true, null, null, "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Email", "FirstName", "IsActive", "LastName", "LastUpdatedAt", "LastUpdatedBy", "Password" },
                values: new object[] { new Guid("3fac7eef-44f2-4f7b-bd6b-8f6457248865"), new DateTime(2023, 11, 27, 16, 23, 16, 524, DateTimeKind.Local).AddTicks(7116), "mainSeed", null, null, "admin@mail.com", "First", true, "Admin", null, null, "Password" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1094bade-087b-4eca-b0c3-c0bc47e52b7a"), new DateTime(2023, 11, 27, 16, 23, 16, 524, DateTimeKind.Local).AddTicks(7316), "", null, null, true, null, null, new Guid("04e0e210-bd83-40d3-8610-4d671991bbd8"), new Guid("baa6230e-bb80-4952-b156-45e127f1d511") },
                    { new Guid("742530ea-2432-4bc0-b938-e3f14645a676"), new DateTime(2023, 11, 27, 16, 23, 16, 524, DateTimeKind.Local).AddTicks(7319), "", null, null, true, null, null, new Guid("0d585130-d133-43ba-a726-5604ddaa81de"), new Guid("baa6230e-bb80-4952-b156-45e127f1d511") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "RoleId", "UserId" },
                values: new object[] { new Guid("f7948c9b-bac2-4795-8fab-e66ff1c57d48"), new DateTime(2023, 11, 27, 22, 23, 16, 524, DateTimeKind.Utc).AddTicks(7344), "mainSeed", null, null, true, null, null, new Guid("baa6230e-bb80-4952-b156-45e127f1d511"), new Guid("3fac7eef-44f2-4f7b-bd6b-8f6457248865") });
        }
    }
}
