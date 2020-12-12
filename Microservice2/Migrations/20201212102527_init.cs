using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Turnover = table.Column<int>(type: "int", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ceo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BoardOfDirectors = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStockPrice = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StockExchange = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PricePerShare = table.Column<int>(type: "int", nullable: false),
                    TotalNumberOfShares = table.Column<int>(type: "int", nullable: false),
                    OpenDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StockExchange = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CurrentPrice = table.Column<int>(type: "int", nullable: false),
                    DateOfPrice = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPrice", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Ipo");

            migrationBuilder.DropTable(
                name: "StockPrice");
        }
    }
}
