using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_105 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Educations");

            migrationBuilder.AddColumn<int>(
                name: "_From",
                table: "Educations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_To",
                table: "Educations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_From",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "_To",
                table: "Educations");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
