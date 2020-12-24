using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_118 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "InterviewDates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeDate",
                table: "InterviewDates",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeDate",
                table: "InterviewDates",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStart",
                table: "InterviewDates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
