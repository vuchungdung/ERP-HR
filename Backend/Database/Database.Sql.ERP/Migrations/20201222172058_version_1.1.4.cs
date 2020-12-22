using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_114 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateId",
                table: "InterviewResults");

            migrationBuilder.AddColumn<int>(
                name: "InterviewProcessId",
                table: "InterviewResults",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterviewProcessId",
                table: "InterviewResults");

            migrationBuilder.AddColumn<int>(
                name: "DateId",
                table: "InterviewResults",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
