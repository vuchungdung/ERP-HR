using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Candidates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Candidates");
        }
    }
}
