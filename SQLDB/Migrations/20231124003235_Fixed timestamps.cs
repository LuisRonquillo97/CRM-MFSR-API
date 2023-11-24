using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLDB.Migrations
{
    /// <inheritdoc />
    public partial class Fixedtimestamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("36f4f48b-39a7-4116-8b7d-2521af944216"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3f4765ef-30bc-47a3-959c-d36e26ae57de"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3240b2f6-b1b5-476a-995b-85c27a9bb611"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeactivatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "UserRoles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeactivatedAt",
                table: "UserRoles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeactivatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeactivatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "UserRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeactivatedAt",
                table: "UserRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeactivatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Description", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "Name" },
                values: new object[] { new Guid("3f4765ef-30bc-47a3-959c-d36e26ae57de"), new DateTime(2023, 11, 23, 12, 38, 16, 853, DateTimeKind.Local).AddTicks(5966), "mainSeed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Has full permissions.", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "Email", "FirstName", "IsActive", "LastName", "LastUpdatedAt", "LastUpdatedBy", "Password" },
                values: new object[] { new Guid("3240b2f6-b1b5-476a-995b-85c27a9bb611"), new DateTime(2023, 11, 23, 12, 38, 16, 853, DateTimeKind.Local).AddTicks(5882), "mainSeed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@mail.com", "First", true, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Password" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeactivatedAt", "DeactivatedBy", "IsActive", "LastUpdatedAt", "LastUpdatedBy", "RoleId", "UserId" },
                values: new object[] { new Guid("36f4f48b-39a7-4116-8b7d-2521af944216"), new DateTime(2023, 11, 23, 18, 38, 16, 853, DateTimeKind.Utc).AddTicks(5983), "mainSeed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3f4765ef-30bc-47a3-959c-d36e26ae57de"), new Guid("3240b2f6-b1b5-476a-995b-85c27a9bb611") });
        }
    }
}
