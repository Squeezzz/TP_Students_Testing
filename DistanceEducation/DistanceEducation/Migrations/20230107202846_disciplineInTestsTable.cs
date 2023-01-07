using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistanceEducation.Migrations
{
    public partial class disciplineInTestsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisciplineId",
                table: "tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tests_DisciplineId",
                table: "tests",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_tests_disciplines_DisciplineId",
                table: "tests",
                column: "DisciplineId",
                principalTable: "disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tests_disciplines_DisciplineId",
                table: "tests");

            migrationBuilder.DropIndex(
                name: "IX_tests_DisciplineId",
                table: "tests");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "tests");
        }
    }
}
