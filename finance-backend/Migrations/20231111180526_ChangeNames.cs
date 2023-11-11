using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finance_backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "incomes",
                keyColumn: "id",
                keyValue: new Guid("35e3fe02-85f3-4713-a745-3b598fad63f2"));

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "balances",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "balances",
                newName: "categoryId");

            migrationBuilder.InsertData(
                table: "incomes",
                columns: new[] { "id", "amount", "title" },
                values: new object[] { new Guid("1355bfe6-6e4f-4cf7-97df-dfa1dac530e8"), 2000f, "Покупочки" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "incomes",
                keyColumn: "id",
                keyValue: new Guid("1355bfe6-6e4f-4cf7-97df-dfa1dac530e8"));

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "balances",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "balances",
                newName: "id");

            migrationBuilder.InsertData(
                table: "incomes",
                columns: new[] { "id", "amount", "title" },
                values: new object[] { new Guid("35e3fe02-85f3-4713-a745-3b598fad63f2"), 2000f, "Покупочки" });
        }
    }
}
