using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentGradebookApi.Migrations
{
    /// <inheritdoc />
    public partial class ClassSubjectNullableTeacers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjects_Teachers_TeacherId",
                table: "ClassSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "ClassSubjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjects_Teachers_TeacherId",
                table: "ClassSubjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjects_Teachers_TeacherId",
                table: "ClassSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "ClassSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjects_Teachers_TeacherId",
                table: "ClassSubjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
