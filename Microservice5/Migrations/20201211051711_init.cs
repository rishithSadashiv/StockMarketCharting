using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice5.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockExchange",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StockExchangeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Brief = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContackAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockExchangeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stockExchangeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_StockExchange_stockExchangeId",
                        column: x => x.stockExchangeId,
                        principalTable: "StockExchange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_stockExchangeId",
                table: "Company",
                column: "stockExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "StockExchange");
        }
    }
}
