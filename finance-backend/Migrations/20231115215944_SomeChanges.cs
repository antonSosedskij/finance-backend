using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finance_backend.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_balances_categories_CategoryId",
                table: "balances");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "balances",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_balances_CategoryId",
                table: "balances",
                newName: "IX_balances_category_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "incomes",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "incomes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "balances",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_incomes_OwnerId",
                table: "incomes",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_balances_UserId",
                table: "balances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_balances_categories_category_id",
                table: "balances",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_balances_users_UserId",
                table: "balances",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_incomes_users_OwnerId",
                table: "incomes",
                column: "OwnerId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_balances_categories_category_id",
                table: "balances");

            migrationBuilder.DropForeignKey(
                name: "FK_balances_users_UserId",
                table: "balances");

            migrationBuilder.DropForeignKey(
                name: "FK_incomes_users_OwnerId",
                table: "incomes");

            migrationBuilder.DropIndex(
                name: "IX_incomes_OwnerId",
                table: "incomes");

            migrationBuilder.DropIndex(
                name: "IX_balances_UserId",
                table: "balances");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "incomes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "balances");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "balances",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_balances_category_id",
                table: "balances",
                newName: "IX_balances_CategoryId");

            migrationBuilder.AlterColumn<float>(
                name: "amount",
                table: "incomes",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddForeignKey(
                name: "FK_balances_categories_CategoryId",
                table: "balances",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
