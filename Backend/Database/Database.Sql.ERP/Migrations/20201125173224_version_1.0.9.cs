using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_109 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadidateUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Skill",
                table: "Cadidates",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Cadidates",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cadidates",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Cadidates",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Cadidates",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Cadidates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Cadidates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Cadidates");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Cadidates");

            migrationBuilder.AlterColumn<string>(
                name: "Skill",
                table: "Cadidates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Cadidates",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cadidates",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Cadidates",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Cadidates",
                type: "nvarchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CadidateUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadidateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "varchar(120)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadidateUsers", x => x.UserId);
                });
        }
    }
}
