using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quatity",
                table: "InterviewDates");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "InterviewDates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "InterviewDates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "InterviewDates");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "InterviewDates");

            migrationBuilder.AddColumn<int>(
                name: "Quatity",
                table: "InterviewDates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
