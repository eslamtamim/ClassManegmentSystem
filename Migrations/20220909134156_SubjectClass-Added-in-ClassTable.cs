using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassManegmentSystem.Migrations
{
    public partial class SubjectClassAddedinClassTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassSubject",
                table: "classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassSubject",
                table: "classes");
        }
    }
}
