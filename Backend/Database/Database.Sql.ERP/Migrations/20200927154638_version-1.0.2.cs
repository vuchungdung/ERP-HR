using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Cadidates");

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Providers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Providers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Providers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Providers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Providers",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "Cadidates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "Cadidates",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "Cadidates");

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Cadidates",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkillId",
                table: "Cadidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
