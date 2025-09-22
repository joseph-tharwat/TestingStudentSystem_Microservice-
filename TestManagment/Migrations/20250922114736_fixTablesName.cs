using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManagment.Migrations
{
    /// <inheritdoc />
    public partial class fixTablesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsQuestions_Question_QuestionId",
                table: "TestsQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestsQuestions_Test_TestId",
                table: "TestsQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestsScheduling_Test_TestId",
                table: "TestsScheduling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Test",
                table: "Test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "Test",
                newName: "Tests");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestsQuestions_Questions_QuestionId",
                table: "TestsQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestsQuestions_Tests_TestId",
                table: "TestsQuestions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestsScheduling_Tests_TestId",
                table: "TestsScheduling",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsQuestions_Questions_QuestionId",
                table: "TestsQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestsQuestions_Tests_TestId",
                table: "TestsQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestsScheduling_Tests_TestId",
                table: "TestsScheduling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Tests",
                newName: "Test");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Test",
                table: "Test",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestsQuestions_Question_QuestionId",
                table: "TestsQuestions",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestsQuestions_Test_TestId",
                table: "TestsQuestions",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestsScheduling_Test_TestId",
                table: "TestsScheduling",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
