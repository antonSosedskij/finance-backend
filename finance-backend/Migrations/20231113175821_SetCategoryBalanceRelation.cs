using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finance_backend.Migrations
{
    /// <inheritdoc />
    public partial class SetCategoryBalanceRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_balances_CategoryId",
                table: "balances",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_balances_categories_CategoryId",
                table: "balances",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_balances_categories_CategoryId",
                table: "balances");

            migrationBuilder.DropIndex(
                name: "IX_balances_CategoryId",
                table: "balances");
        }
    }
}
