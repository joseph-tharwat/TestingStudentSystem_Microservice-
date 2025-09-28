using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addStudentIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentGrades",
                table: "StudentGrades");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentGrades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentGrades",
                table: "StudentGrades",
                columns: new[] { "QuestionId", "TestId", "StudentId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentGrades",
                table: "StudentGrades");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentGrades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentGrades",
                table: "StudentGrades",
                columns: new[] { "QuestionId", "TestId" });
        }
    }
}
