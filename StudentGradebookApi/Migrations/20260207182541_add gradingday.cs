using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentGradebookApi.Migrations
{
    /// <inheritdoc />
    public partial class addgradingday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "GradingDay",
                table: "Grades",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "CAST([GradingDate] AS date)",
                stored: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_GradingDay_EnrollmentId",
                table: "Grades",
                columns: new[] { "GradingDay", "EnrollmentId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Grades_GradingDay_EnrollmentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "GradingDay",
                table: "Grades");
        }
    }
}
