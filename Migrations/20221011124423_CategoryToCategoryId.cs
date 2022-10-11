using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    public partial class CategoryToCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Categories_CategoryGuid",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CategoryGuid",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CategoryGuid",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Transactions");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryGuid",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryGuid",
                table: "Transactions",
                column: "CategoryGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Categories_CategoryGuid",
                table: "Transactions",
                column: "CategoryGuid",
                principalTable: "Categories",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
