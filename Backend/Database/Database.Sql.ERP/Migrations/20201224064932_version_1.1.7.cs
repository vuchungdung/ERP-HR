using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_117 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ResultDate",
                table: "InterviewProcesses",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultDate",
                table: "InterviewProcesses");
        }
    }
}
