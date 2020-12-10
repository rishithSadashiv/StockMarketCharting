using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice5.Migrations
{
    public partial class onetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockExchangeName",
                table: "Company",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Company",
                newName: "StockExchangeName");
        }
    }
}
