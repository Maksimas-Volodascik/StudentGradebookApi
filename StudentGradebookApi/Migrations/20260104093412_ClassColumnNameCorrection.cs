using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentGradebookApi.Migrations
{
    /// <inheritdoc />
    public partial class ClassColumnNameCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Classes_Class_id",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "Class_id",
                table: "Teachers",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_Class_id",
                table: "Teachers",
                newName: "IX_Teachers_ClassId");

            migrationBuilder.AlterColumn<string>(
                name: "AcademicYear",
                table: "Classes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_AcademicYear_Room",
                table: "Classes",
                columns: new[] { "AcademicYear", "Room" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classes_ClassId",
                table: "Teachers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Classes_ClassId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Classes_AcademicYear_Room",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Teachers",
                newName: "Class_id");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers",
                newName: "IX_Teachers_Class_id");

            migrationBuilder.AlterColumn<string>(
                name: "AcademicYear",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classes_Class_id",
                table: "Teachers",
                column: "Class_id",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
