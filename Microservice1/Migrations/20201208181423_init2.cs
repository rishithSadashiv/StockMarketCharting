using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice3.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    turnover = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
