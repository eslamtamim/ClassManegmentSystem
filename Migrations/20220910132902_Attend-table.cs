using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassManegmentSystem.Migrations
{
    public partial class Attendtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    AttendeesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    ClassNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfAttendeens = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.AttendeesId);
                    table.ForeignKey(
                        name: "FK_Attendees_classes_StudentId_TeacherId",
                        columns: x => new { x.StudentId, x.TeacherId },
                        principalTable: "classes",
                        principalColumns: new[] { "StudentId", "TeacherId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_StudentId_TeacherId",
                table: "Attendees",
                columns: new[] { "StudentId", "TeacherId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");
        }
    }
}
