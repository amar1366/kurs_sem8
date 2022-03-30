using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab4.Storage.Migrations
{
    public partial class InitialCreare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepNomber = table.Column<Guid>(nullable: false),
                    DepName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepNomber);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    UniNomber = table.Column<Guid>(nullable: false),
                    DepartamentId = table.Column<Guid>(nullable: false),
                    UniName = table.Column<string>(nullable: false),
                    DepartmentdNomber = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.UniNomber);
                    table.ForeignKey(
                        name: "FK_University_Department_DepartmentdNomber",
                        column: x => x.DepartmentdNomber,
                        principalTable: "Department",
                        principalColumn: "DepNomber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfNomber = table.Column<Guid>(nullable: false),
                    UniversityId = table.Column<Guid>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfNomber);
                    table.ForeignKey(
                        name: "FK_Professor_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "UniNomber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professor_UniversityId",
                table: "Professor",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_University_DepartmentdNomber",
                table: "University",
                column: "DepartmentdNomber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
