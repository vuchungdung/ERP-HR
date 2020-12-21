using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkIn",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "FaceBook",
                table: "Candidates",
                newName: "Facebook");

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Candidates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "Facebook",
                table: "Candidates",
                newName: "FaceBook");

            migrationBuilder.AddColumn<string>(
                name: "LinkIn",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
