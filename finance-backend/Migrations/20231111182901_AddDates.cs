using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finance_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "incomes",
                keyColumn: "id",
                keyValue: new Guid("1355bfe6-6e4f-4cf7-97df-dfa1dac530e8"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "incomes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "incomes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "incomes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "expenses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "expenses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "expenses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "balances",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "balances",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "balances",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "incomes",
                columns: new[] { "id", "amount", "CreatedDate", "RemovedDate", "title", "UpdatedDate" },
                values: new object[] { new Guid("fd0bb89b-bbfa-4704-b486-794ee0a25e62"), 2000f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Покупочки", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "incomes",
                keyColumn: "id",
                keyValue: new Guid("fd0bb89b-bbfa-4704-b486-794ee0a25e62"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "incomes");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "incomes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "incomes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "balances");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "balances");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "balances");

            migrationBuilder.InsertData(
                table: "incomes",
                columns: new[] { "id", "amount", "title" },
                values: new object[] { new Guid("1355bfe6-6e4f-4cf7-97df-dfa1dac530e8"), 2000f, "Покупочки" });
        }
    }
}
