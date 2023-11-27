using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLDB.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("b9ca2fe3-75c3-4e59-826c-84be4c233a21"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d4d9350a-d91f-4075-a750-975959f79d3e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("50b755f3-8e60-4b95-8c77-80cf59aecbc9"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[] { new Guid("d4d9350a-d91f-4075-a750-975959f79d3e"), new DateTime(2023, 11, 23, 18, 32, 35, 229, DateTimeKind.Local).AddTicks(3505), "mainSeed", null, null, "Has full permissions.", true, null, null, "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Email", "FirstName", "IsActive", "LastName", "LastUpdatedAt", "LastUpdatedBy", "Password" },
                values: new object[] { new Guid("50b755f3-8e60-4b95-8c77-80cf59aecbc9"), new DateTime(2023, 11, 23, 18, 32, 35, 229, DateTimeKind.Local).AddTicks(3404), "mainSeed", null, null, "admin@mail.com", "First", true, "Admin", null, null, "Password" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "RoleId", "UserId" },
                values: new object[] { new Guid("b9ca2fe3-75c3-4e59-826c-84be4c233a21"), new DateTime(2023, 11, 24, 0, 32, 35, 229, DateTimeKind.Utc).AddTicks(3520), "mainSeed", null, null, true, null, null, new Guid("d4d9350a-d91f-4075-a750-975959f79d3e"), new Guid("50b755f3-8e60-4b95-8c77-80cf59aecbc9") });
        }
    }
}
