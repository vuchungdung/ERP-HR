using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_112 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "InterviewProcesses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "InterviewProcesses",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "InterviewProcesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "InterviewProcesses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "InterviewProcesses",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "InterviewProcesses");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "InterviewProcesses");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "InterviewProcesses");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "InterviewProcesses");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "InterviewProcesses");
        }
    }
}
