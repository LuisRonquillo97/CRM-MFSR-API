using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLDB.Migrations
{
    /// <inheritdoc />
    public partial class Permissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a85a830-6e21-4b4d-9579-876eb383a346"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("974dbff1-db5e-4871-b1dc-6a39519c76af"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f2d47980-339e-4778-b224-b9e41ec4549e"));

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[] { new Guid("974dbff1-db5e-4871-b1dc-6a39519c76af"), new DateTime(2023, 11, 24, 18, 43, 34, 122, DateTimeKind.Local).AddTicks(9112), "mainSeed", null, null, "Has full permissions.", true, null, null, "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Email", "FirstName", "IsActive", "LastName", "LastUpdatedAt", "LastUpdatedBy", "Password" },
                values: new object[] { new Guid("f2d47980-339e-4778-b224-b9e41ec4549e"), new DateTime(2023, 11, 24, 18, 43, 34, 122, DateTimeKind.Local).AddTicks(9015), "mainSeed", null, null, "admin@mail.com", "First", true, "Admin", null, null, "Password" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "RoleId", "UserId" },
                values: new object[] { new Guid("2a85a830-6e21-4b4d-9579-876eb383a346"), new DateTime(2023, 11, 25, 0, 43, 34, 122, DateTimeKind.Utc).AddTicks(9131), "mainSeed", null, null, true, null, null, new Guid("974dbff1-db5e-4871-b1dc-6a39519c76af"), new Guid("f2d47980-339e-4778-b224-b9e41ec4549e") });
        }
    }
}
