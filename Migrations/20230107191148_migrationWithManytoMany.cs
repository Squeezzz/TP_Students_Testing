using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistanceEducation.Migrations
{
    public partial class migrationWithManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTeacher");

            migrationBuilder.CreateTable(
                name: "groupTeachers",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupTeachers", x => new { x.GroupsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_groupTeachers_groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_groupTeachers_teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_groupTeachers_TeachersId",
                table: "groupTeachers",
                column: "TeachersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "groupTeachers");

            migrationBuilder.CreateTable(
                name: "GroupTeacher",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTeacher", x => new { x.GroupsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_GroupTeacher_groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTeacher_teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupTeacher_TeachersId",
                table: "GroupTeacher",
                column: "TeachersId");
        }
    }
}
