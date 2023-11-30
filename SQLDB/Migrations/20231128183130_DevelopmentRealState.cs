using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SQLDB.Migrations
{
    /// <inheritdoc />
    public partial class DevelopmentRealState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Developments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResourcesUri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_Developments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LotCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_LotCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DevelopmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerSquareMeter = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Developments_DevelopmentId",
                        column: x => x.DevelopmentId,
                        principalTable: "Developments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FrontMeters = table.Column<double>(type: "float", nullable: false),
                    BottomMeters = table.Column<double>(type: "float", nullable: false),
                    PricePerSquareMeterUsed = table.Column<double>(type: "float", nullable: false),
                    LotCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Lots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lots_LotCategories_LotCategoryId",
                        column: x => x.LotCategoryId,
                        principalTable: "LotCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lots_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Lots_StageId",
                table: "Lots",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_DevelopmentId",
                table: "Stages",
                column: "DevelopmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "LotCategories");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Developments");

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
        }
    }
}
