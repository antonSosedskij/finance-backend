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
            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "incomes",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "incomes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "balances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_incomes_UserId",
                table: "incomes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_balances_UserId",
                table: "balances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_balances_users_UserId",
                table: "balances",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_incomes_users_UserId",
                table: "incomes",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_balances_users_UserId",
                table: "balances");

            migrationBuilder.DropForeignKey(
                name: "FK_incomes_users_UserId",
                table: "incomes");

            migrationBuilder.DropIndex(
                name: "IX_incomes_UserId",
                table: "incomes");

            migrationBuilder.DropIndex(
                name: "IX_balances_UserId",
                table: "balances");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "incomes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "balances");

            migrationBuilder.AlterColumn<float>(
                name: "amount",
                table: "incomes",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
