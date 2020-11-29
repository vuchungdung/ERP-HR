using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceBook",
                table: "Cadidates");

            migrationBuilder.DropColumn(
                name: "LinkIn",
                table: "Cadidates");

            migrationBuilder.DropColumn(
                name: "Zalo",
                table: "Cadidates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaceBook",
                table: "Cadidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkIn",
                table: "Cadidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zalo",
                table: "Cadidates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
