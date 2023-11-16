using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finance_backend.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "expenses",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_expenses_balanceId",
                table: "expenses",
                column: "balanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_balances_balanceId",
                table: "expenses",
                column: "balanceId",
                principalTable: "balances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_balances_balanceId",
                table: "expenses");

            migrationBuilder.DropIndex(
                name: "IX_expenses_balanceId",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "expenses");
        }
    }
}
