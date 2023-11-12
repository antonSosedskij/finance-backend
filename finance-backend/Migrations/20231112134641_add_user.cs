using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finance_backend.Migrations
{
    /// <inheritdoc />
    public partial class add_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "incomes",
                keyColumn: "id",
                keyValue: new Guid("fd0bb89b-bbfa-4704-b486-794ee0a25e62"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "incomes",
                columns: new[] { "id", "amount", "CreatedDate", "RemovedDate", "title", "UpdatedDate" },
                values: new object[] { new Guid("fd0bb89b-bbfa-4704-b486-794ee0a25e62"), 2000f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Покупочки", null });
        }
    }
}
