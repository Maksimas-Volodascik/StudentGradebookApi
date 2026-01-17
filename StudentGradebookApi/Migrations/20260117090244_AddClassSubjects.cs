using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentGradebookApi.Migrations
{
    /// <inheritdoc />
    public partial class AddClassSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Classes_ClassId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_ClassId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "ClassID",
                table: "Enrollments",
                newName: "ClassSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentID_ClassID",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentID_ClassSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_ClassID",
                table: "Enrollments",
                newName: "IX_Enrollments_ClassSubjectId");

            migrationBuilder.AddColumn<int>(
                name: "ClassesId",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClassesId",
                table: "Enrollments",
                column: "ClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_ClassId",
                table: "ClassSubjects",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_SubjectId_ClassId",
                table: "ClassSubjects",
                columns: new[] { "SubjectId", "ClassId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_TeacherId",
                table: "ClassSubjects",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_ClassSubjects_ClassSubjectId",
                table: "Enrollments",
                column: "ClassSubjectId",
                principalTable: "ClassSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Classes_ClassesId",
                table: "Enrollments",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_ClassSubjects_ClassSubjectId",
                table: "Enrollments");

            migrationBuilder.DropTable(
                name: "ClassSubjects");

            migrationBuilder.DropColumn(
                name: "ClassesId",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "ClassSubjectId",
                table: "Enrollments",
                newName: "ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentID_ClassSubjectId",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentID_ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_ClassSubjectId",
                table: "Enrollments",
                newName: "IX_Enrollments_ClassID");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers",
                column: "ClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ClassId",
                table: "Subjects",
                column: "ClassId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Classes_ClassID",
                table: "Enrollments",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                table: "Subjects",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classes_ClassId",
                table: "Teachers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
