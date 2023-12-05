using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SQLDB.Migrations
{
    /// <inheritdoc />
    public partial class fixedUniqueValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("5f0a99a1-c826-4019-9da6-1cf8b457a6ff"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c8295d7d-957f-4842-bd21-14538097ad1e"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("612f4323-88c5-4e3f-918d-9905df66fc6f"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("296d0bc9-29c6-47cf-a49c-d8fec866d71b"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("d166fe86-7a9a-40e2-b01b-b0aa956f14fa"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b1c56af6-7013-41bf-84b1-3a2014b68987"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0706d189-dadf-478e-b716-d5bf62a20bd5"));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "Key", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("31851b9e-091b-4755-8d35-d1cfbc7110d2"), new DateTime(2023, 12, 5, 10, 24, 57, 120, DateTimeKind.Local).AddTicks(5766), "MainSeed", null, null, "Create users.", true, "User.Create", null, null, "Create users" },
                    { new Guid("f2824bc7-0ea1-4f18-9fcf-092cbf75ec69"), new DateTime(2023, 12, 5, 10, 24, 57, 120, DateTimeKind.Local).AddTicks(5763), "MainSeed", null, null, "See all users for the role Admin.", true, "User.See", null, null, "See users" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[] { new Guid("12b1c2b4-c6f3-43cf-8bc2-77e9b6ff0ad1"), new DateTime(2023, 12, 5, 10, 24, 57, 120, DateTimeKind.Local).AddTicks(5712), "mainSeed", null, null, "Has full permissions.", true, null, null, "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Email", "FirstName", "IsActive", "LastName", "LastUpdatedAt", "LastUpdatedBy", "Password" },
                values: new object[] { new Guid("59aa1454-a84e-4072-968b-221d8a2d20fe"), new DateTime(2023, 12, 5, 10, 24, 57, 120, DateTimeKind.Local).AddTicks(5564), "mainSeed", null, null, "admin@mail.com", "First", true, "Admin", null, null, "Password" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("616d58f9-022a-4383-97c5-f9ed8bbd2ae2"), new DateTime(2023, 12, 5, 10, 24, 57, 120, DateTimeKind.Local).AddTicks(5786), "", null, null, true, null, null, new Guid("31851b9e-091b-4755-8d35-d1cfbc7110d2"), new Guid("12b1c2b4-c6f3-43cf-8bc2-77e9b6ff0ad1") },
                    { new Guid("ba950a54-58d9-49f9-84c6-5c68367d76a2"), new DateTime(2023, 12, 5, 10, 24, 57, 120, DateTimeKind.Local).AddTicks(5783), "", null, null, true, null, null, new Guid("f2824bc7-0ea1-4f18-9fcf-092cbf75ec69"), new Guid("12b1c2b4-c6f3-43cf-8bc2-77e9b6ff0ad1") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "RoleId", "UserId" },
                values: new object[] { new Guid("6e9aea3b-e597-4050-9536-beae3c57dff7"), new DateTime(2023, 12, 5, 10, 24, 57, 120, DateTimeKind.Local).AddTicks(5805), "mainSeed", null, null, true, null, null, new Guid("12b1c2b4-c6f3-43cf-8bc2-77e9b6ff0ad1"), new Guid("59aa1454-a84e-4072-968b-221d8a2d20fe") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("616d58f9-022a-4383-97c5-f9ed8bbd2ae2"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ba950a54-58d9-49f9-84c6-5c68367d76a2"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("6e9aea3b-e597-4050-9536-beae3c57dff7"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("31851b9e-091b-4755-8d35-d1cfbc7110d2"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f2824bc7-0ea1-4f18-9fcf-092cbf75ec69"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("12b1c2b4-c6f3-43cf-8bc2-77e9b6ff0ad1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("59aa1454-a84e-4072-968b-221d8a2d20fe"));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "Key", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("296d0bc9-29c6-47cf-a49c-d8fec866d71b"), new DateTime(2023, 11, 29, 18, 10, 43, 742, DateTimeKind.Local).AddTicks(8296), "MainSeed", null, null, "Create users.", true, "User.Create", null, null, "Create users" },
                    { new Guid("d166fe86-7a9a-40e2-b01b-b0aa956f14fa"), new DateTime(2023, 11, 29, 18, 10, 43, 742, DateTimeKind.Local).AddTicks(8294), "MainSeed", null, null, "See all users for the role Admin.", true, "User.See", null, null, "See users" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[] { new Guid("b1c56af6-7013-41bf-84b1-3a2014b68987"), new DateTime(2023, 11, 29, 18, 10, 43, 742, DateTimeKind.Local).AddTicks(8267), "mainSeed", null, null, "Has full permissions.", true, null, null, "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Email", "FirstName", "IsActive", "LastName", "LastUpdatedAt", "LastUpdatedBy", "Password" },
                values: new object[] { new Guid("0706d189-dadf-478e-b716-d5bf62a20bd5"), new DateTime(2023, 11, 29, 18, 10, 43, 742, DateTimeKind.Local).AddTicks(8045), "mainSeed", null, null, "admin@mail.com", "First", true, "Admin", null, null, "Password" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("5f0a99a1-c826-4019-9da6-1cf8b457a6ff"), new DateTime(2023, 11, 29, 18, 10, 43, 742, DateTimeKind.Local).AddTicks(8322), "", null, null, true, null, null, new Guid("296d0bc9-29c6-47cf-a49c-d8fec866d71b"), new Guid("b1c56af6-7013-41bf-84b1-3a2014b68987") },
                    { new Guid("c8295d7d-957f-4842-bd21-14538097ad1e"), new DateTime(2023, 11, 29, 18, 10, 43, 742, DateTimeKind.Local).AddTicks(8319), "", null, null, true, null, null, new Guid("d166fe86-7a9a-40e2-b01b-b0aa956f14fa"), new Guid("b1c56af6-7013-41bf-84b1-3a2014b68987") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "RoleId", "UserId" },
                values: new object[] { new Guid("612f4323-88c5-4e3f-918d-9905df66fc6f"), new DateTime(2023, 11, 29, 18, 10, 43, 742, DateTimeKind.Local).AddTicks(8348), "mainSeed", null, null, true, null, null, new Guid("b1c56af6-7013-41bf-84b1-3a2014b68987"), new Guid("0706d189-dadf-478e-b716-d5bf62a20bd5") });
        }
    }
}
