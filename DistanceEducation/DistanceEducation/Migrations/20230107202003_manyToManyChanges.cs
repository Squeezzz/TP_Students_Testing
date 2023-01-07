using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistanceEducation.Migrations
{
    public partial class manyToManyChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplineGroup");

            migrationBuilder.DropTable(
                name: "DisciplineTeacher");

            migrationBuilder.CreateTable(
                name: "disciplineGroups",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    GroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplineGroups", x => new { x.DisciplineId, x.GroupsId });
                    table.ForeignKey(
                        name: "FK_disciplineGroups_disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_disciplineGroups_groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "disciplineTeachers",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplineTeachers", x => new { x.DisciplineId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_disciplineTeachers_disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_disciplineTeachers_teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_disciplineGroups_GroupsId",
                table: "disciplineGroups",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_disciplineTeachers_TeacherId",
                table: "disciplineTeachers",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "disciplineGroups");

            migrationBuilder.DropTable(
                name: "disciplineTeachers");

            migrationBuilder.CreateTable(
                name: "DisciplineGroup",
                columns: table => new
                {
                    DisciplinesId = table.Column<int>(type: "int", nullable: false),
                    GroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineGroup", x => new { x.DisciplinesId, x.GroupsId });
                    table.ForeignKey(
                        name: "FK_DisciplineGroup_disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineGroup_groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineTeacher",
                columns: table => new
                {
                    DisciplinesId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineTeacher", x => new { x.DisciplinesId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_DisciplineTeacher_disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineTeacher_teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineGroup_GroupsId",
                table: "DisciplineGroup",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineTeacher_TeachersId",
                table: "DisciplineTeacher",
                column: "TeachersId");
        }
    }
}
