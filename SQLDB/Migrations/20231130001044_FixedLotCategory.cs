using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SQLDB.Migrations
{
    /// <inheritdoc />
    public partial class FixedLotCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lots_LotCategoryId",
                table: "Lots");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("3d382b60-34e8-4324-bc94-247a5a34c1c5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b6dceccf-8c6b-4538-935f-8c80246677a3"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("9d7e0c8a-4a1f-4961-a116-5cf57356d107"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("3df5728a-3b47-49a5-a83b-dd20dc1616fa"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("86f79e6a-6ac9-43a0-aa9d-aee0654ef297"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a583a752-4106-4d14-9c10-a7bf6535bbba"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("462d8c81-2e21-447e-9d33-8131b9608999"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Lots_LotCategoryId",
                table: "Lots",
                column: "LotCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lots_LotCategoryId",
                table: "Lots");

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
                    { new Guid("3df5728a-3b47-49a5-a83b-dd20dc1616fa"), new DateTime(2023, 11, 28, 18, 31, 30, 19, DateTimeKind.Utc).AddTicks(1357), "MainSeed", null, null, "Create users.", true, "User.Create", null, null, "Create users" },
                    { new Guid("86f79e6a-6ac9-43a0-aa9d-aee0654ef297"), new DateTime(2023, 11, 28, 18, 31, 30, 19, DateTimeKind.Utc).AddTicks(1347), "MainSeed", null, null, "See all users for the role Admin.", true, "User.See", null, null, "See users" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[] { new Guid("a583a752-4106-4d14-9c10-a7bf6535bbba"), new DateTime(2023, 11, 28, 12, 31, 30, 19, DateTimeKind.Local).AddTicks(1327), "mainSeed", null, null, "Has full permissions.", true, null, null, "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Email", "FirstName", "IsActive", "LastName", "LastUpdatedAt", "LastUpdatedBy", "Password" },
                values: new object[] { new Guid("462d8c81-2e21-447e-9d33-8131b9608999"), new DateTime(2023, 11, 28, 12, 31, 30, 19, DateTimeKind.Local).AddTicks(1221), "mainSeed", null, null, "admin@mail.com", "First", true, "Admin", null, null, "Password" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("3d382b60-34e8-4324-bc94-247a5a34c1c5"), new DateTime(2023, 11, 28, 12, 31, 30, 19, DateTimeKind.Local).AddTicks(1372), "", null, null, true, null, null, new Guid("3df5728a-3b47-49a5-a83b-dd20dc1616fa"), new Guid("a583a752-4106-4d14-9c10-a7bf6535bbba") },
                    { new Guid("b6dceccf-8c6b-4538-935f-8c80246677a3"), new DateTime(2023, 11, 28, 12, 31, 30, 19, DateTimeKind.Local).AddTicks(1371), "", null, null, true, null, null, new Guid("86f79e6a-6ac9-43a0-aa9d-aee0654ef297"), new Guid("a583a752-4106-4d14-9c10-a7bf6535bbba") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "RoleId", "UserId" },
                values: new object[] { new Guid("9d7e0c8a-4a1f-4961-a116-5cf57356d107"), new DateTime(2023, 11, 28, 18, 31, 30, 19, DateTimeKind.Utc).AddTicks(1394), "mainSeed", null, null, true, null, null, new Guid("a583a752-4106-4d14-9c10-a7bf6535bbba"), new Guid("462d8c81-2e21-447e-9d33-8131b9608999") });

            migrationBuilder.CreateIndex(
                name: "IX_Lots_LotCategoryId",
                table: "Lots",
                column: "LotCategoryId",
                unique: true);
        }
    }
}
