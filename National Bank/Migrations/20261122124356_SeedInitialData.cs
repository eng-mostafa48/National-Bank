using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace National_Bank.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ahmed@bank.com", "Ahmed Mohamed", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01012345678" },
                    { 2, "sara@bank.com", "Sara Ali", new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01098765432" },
                    { 3, "omar@bank.com", "Omar Hassan", new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01112345678" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "ManagerId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "BR001", "Tanta, Gharbia", 1, "Tanta Main Branch", "0401234567" },
                    { "BR002", "Cairo", 2, "Cairo Branch", "0223456789" },
                    { "BR003", "Alexandria", 3, "Alexandria Branch", "0345678901" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "BR001");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "BR002");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "BR003");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
