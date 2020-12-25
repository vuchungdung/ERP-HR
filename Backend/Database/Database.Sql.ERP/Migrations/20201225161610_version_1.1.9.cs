using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_119 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JodId",
                table: "InterviewDates");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "InterviewDates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobId",
                table: "InterviewDates");

            migrationBuilder.AddColumn<int>(
                name: "JodId",
                table: "InterviewDates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
