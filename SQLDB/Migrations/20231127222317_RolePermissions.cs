using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SQLDB.Migrations
{
    /// <inheritdoc />
    public partial class RolePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_IdRole",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_IdRole",
                table: "Permissions");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("d7368da3-cc3d-4862-a435-5e5636f82014"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("6e57d031-01b6-40f5-a089-a6e40884bc02"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("381dd445-a67c-4a24-bbb7-0d7814b09cca"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a9c61db9-ec53-4907-b82c-f6979bd6604c"));

            migrationBuilder.DropColumn(
                name: "IdRole",
                table: "Permissions");

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeactivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("04e0e210-bd83-40d3-8610-4d671991bbd8"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0d585130-d133-43ba-a726-5604ddaa81de"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("f7948c9b-bac2-4795-8fab-e66ff1c57d48"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("baa6230e-bb80-4952-b156-45e127f1d511"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3fac7eef-44f2-4f7b-bd6b-8f6457248865"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdRole",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[] { new Guid("381dd445-a67c-4a24-bbb7-0d7814b09cca"), new DateTime(2023, 11, 27, 12, 53, 27, 626, DateTimeKind.Local).AddTicks(4456), "mainSeed", null, null, "Has full permissions.", true, null, null, "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Email", "FirstName", "IsActive", "LastName", "LastUpdatedAt", "LastUpdatedBy", "Password" },
                values: new object[] { new Guid("a9c61db9-ec53-4907-b82c-f6979bd6604c"), new DateTime(2023, 11, 27, 12, 53, 27, 626, DateTimeKind.Local).AddTicks(4335), "mainSeed", null, null, "admin@mail.com", "First", true, "Admin", null, null, "Password" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IdRole", "IsActive", "Key", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[] { new Guid("d7368da3-cc3d-4862-a435-5e5636f82014"), new DateTime(2023, 11, 27, 18, 53, 27, 626, DateTimeKind.Utc).AddTicks(4505), "MainSeed", null, null, "Has all permissions. only for the role Admin.", new Guid("381dd445-a67c-4a24-bbb7-0d7814b09cca"), true, "All.All", null, null, "Admin master permission" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "RoleId", "UserId" },
                values: new object[] { new Guid("6e57d031-01b6-40f5-a089-a6e40884bc02"), new DateTime(2023, 11, 27, 18, 53, 27, 626, DateTimeKind.Utc).AddTicks(4482), "mainSeed", null, null, true, null, null, new Guid("381dd445-a67c-4a24-bbb7-0d7814b09cca"), new Guid("a9c61db9-ec53-4907-b82c-f6979bd6604c") });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_IdRole",
                table: "Permissions",
                column: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_IdRole",
                table: "Permissions",
                column: "IdRole",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
