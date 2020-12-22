using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterviewProcessId",
                table: "InterviewResults");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "InterviewProcesses");

            migrationBuilder.AddColumn<int>(
                name: "DateId",
                table: "InterviewResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "InterviewProcesses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateId",
                table: "InterviewResults");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "InterviewProcesses");

            migrationBuilder.AddColumn<int>(
                name: "InterviewProcessId",
                table: "InterviewResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DateId",
                table: "InterviewProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
