using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice3.Migrations
{
    public partial class sector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "turnover",
                table: "Company",
                newName: "Turnover");

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    SectorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Brief = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.SectorID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.RenameColumn(
                name: "Turnover",
                table: "Company",
                newName: "turnover");
        }
    }
}
