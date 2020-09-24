using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CadidateUsers",
                table: "CadidateUsers");

            migrationBuilder.DropSequence(
                name: "ERPSequence");

            migrationBuilder.DropColumn(
                name: "CatidateUserId",
                table: "CadidateUsers");

            migrationBuilder.EnsureSchema(
                name: "shared");

            migrationBuilder.CreateSequence<int>(
                name: "Cadidates",
                schema: "shared");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CadidateUsers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CadidateId",
                table: "CadidateUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CadidateUsers",
                table: "CadidateUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CadidateUsers",
                table: "CadidateUsers");

            migrationBuilder.DropSequence(
                name: "Cadidates",
                schema: "shared");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CadidateUsers");

            migrationBuilder.DropColumn(
                name: "CadidateId",
                table: "CadidateUsers");

            migrationBuilder.CreateSequence(
                name: "ERPSequence");

            migrationBuilder.AddColumn<int>(
                name: "CatidateUserId",
                table: "CadidateUsers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CadidateUsers",
                table: "CadidateUsers",
                column: "CatidateUserId");
        }
    }
}
