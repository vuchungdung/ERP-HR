using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_120 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "InterviewProcesses");

            migrationBuilder.AddColumn<int>(
                name: "ApplyId",
                table: "InterviewProcesses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyId",
                table: "InterviewProcesses");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "InterviewProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
