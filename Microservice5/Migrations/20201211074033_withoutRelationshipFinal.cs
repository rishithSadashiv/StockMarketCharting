using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice5.Migrations
{
    public partial class withoutRelationshipFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyCode",
                table: "Company",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyCode",
                table: "Company",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
