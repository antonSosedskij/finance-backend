using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finance_backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationsConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_UserId1",
                table: "categories",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_users_UserId1",
                table: "categories",
                column: "UserId1",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_users_UserId1",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_UserId1",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "categories");
        }
    }
}
