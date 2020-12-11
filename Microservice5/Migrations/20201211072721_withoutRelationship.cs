using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice5.Migrations
{
    public partial class withoutRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_StockExchange_stockExchangeId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_stockExchangeId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "stockExchangeId",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "ContackAddress",
                table: "StockExchange",
                newName: "ContactAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactAddress",
                table: "StockExchange",
                newName: "ContackAddress");

            migrationBuilder.AddColumn<string>(
                name: "stockExchangeId",
                table: "Company",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_stockExchangeId",
                table: "Company",
                column: "stockExchangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_StockExchange_stockExchangeId",
                table: "Company",
                column: "stockExchangeId",
                principalTable: "StockExchange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
