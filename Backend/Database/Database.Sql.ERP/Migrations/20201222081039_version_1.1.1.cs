using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "InterviewResults");

            migrationBuilder.DropColumn(
                name: "DateType",
                table: "InterviewResults");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "InterviewId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Candidates");

            migrationBuilder.AddColumn<int>(
                name: "InterviewProcessId",
                table: "InterviewResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InterviewProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateId = table.Column<int>(nullable: false),
                    ProcessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewProcesses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewProcesses");

            migrationBuilder.DropColumn(
                name: "InterviewProcessId",
                table: "InterviewResults");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "InterviewResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DateType",
                table: "InterviewResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterviewId",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Candidates",
                type: "int",
                nullable: true);
        }
    }
}
