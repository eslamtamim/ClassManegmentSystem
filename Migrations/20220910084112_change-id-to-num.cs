using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassManegmentSystem.Migrations
{
    public partial class changeidtonum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_classes",
                table: "classes");

            migrationBuilder.DropIndex(
                name: "IX_classes_StudentId",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "classes");

            migrationBuilder.AddColumn<string>(
                name: "ClassNumber",
                table: "classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_classes",
                table: "classes",
                columns: new[] { "StudentId", "TeacherId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_classes",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "ClassNumber",
                table: "classes");

            migrationBuilder.AddColumn<string>(
                name: "ClassId",
                table: "classes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_classes",
                table: "classes",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_classes_StudentId",
                table: "classes",
                column: "StudentId");
        }
    }
}
