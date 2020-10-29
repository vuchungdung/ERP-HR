using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "RecruitmentPlans",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Benefit",
                table: "JobDescriptions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequestJob",
                table: "JobDescriptions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "JobDescriptions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "RecruitmentPlans");

            migrationBuilder.DropColumn(
                name: "Benefit",
                table: "JobDescriptions");

            migrationBuilder.DropColumn(
                name: "RequestJob",
                table: "JobDescriptions");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "JobDescriptions");
        }
    }
}