using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice2.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Company",
                newName: "CompanyId");

            migrationBuilder.AddColumn<string>(
                name: "CompanyCode",
                table: "StockPrice",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyCode",
                table: "StockPrice");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Company",
                newName: "CompanyID");
        }
    }
}
