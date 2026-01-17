using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixClassesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Classes_ClassesId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_ClassesId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "ClassesId",
                table: "Enrollments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassesId",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClassesId",
                table: "Enrollments",
                column: "ClassesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Classes_ClassesId",
                table: "Enrollments",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id");
        }
    }
}
