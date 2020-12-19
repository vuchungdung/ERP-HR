using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Awards");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "WorkHistories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_From",
                table: "Awards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_To",
                table: "Awards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "WorkHistories");

            migrationBuilder.DropColumn(
                name: "_From",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "_To",
                table: "Awards");

            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "Awards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "To",
                table: "Awards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
