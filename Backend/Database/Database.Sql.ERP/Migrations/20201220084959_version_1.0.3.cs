using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version_103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", nullable: true),
                    Dob = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
