using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationSystem.Infra.DAL.SQL.Migrations
{
    public partial class AddUserForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_EvaluationFormQuestions_Tbl_EvaluationFormQuestionCriterion_CriterionId",
                table: "Tbl_EvaluationFormQuestions");

            migrationBuilder.DropTable(
                name: "Tbl_EvaluationFormQuestionCriterion");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_EvaluationFormQuestions_CriterionId",
                table: "Tbl_EvaluationFormQuestions");

            migrationBuilder.DropColumn(
                name: "CriterionId",
                table: "Tbl_EvaluationFormQuestions");

            migrationBuilder.AddColumn<byte>(
                name: "UserGroup",
                table: "Tbl_EvaluationForms",
                type: "TinyInt",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Tbl_UserEvaluationForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvaluationFormId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserEvaluationForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_UserEvaluationForm_Tbl_EvaluationForms_EvaluationFormId",
                        column: x => x.EvaluationFormId,
                        principalTable: "Tbl_EvaluationForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_UserEvaluationForm_Tbl_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserEvaluationFormDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEvaluationFormId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserEvaluationFormDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_UserEvaluationFormDetail_Tbl_UserEvaluationForm_UserEvaluationFormId",
                        column: x => x.UserEvaluationFormId,
                        principalTable: "Tbl_UserEvaluationForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormId",
                table: "Tbl_UserEvaluationForm",
                column: "EvaluationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "Tbl_UserEvaluationForm",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserEvaluationFormDetail_UserEvaluationFormId",
                table: "Tbl_UserEvaluationFormDetail",
                column: "UserEvaluationFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_UserEvaluationFormDetail");

            migrationBuilder.DropTable(
                name: "Tbl_UserEvaluationForm");

            migrationBuilder.DropColumn(
                name: "UserGroup",
                table: "Tbl_EvaluationForms");

            migrationBuilder.AddColumn<int>(
                name: "CriterionId",
                table: "Tbl_EvaluationFormQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tbl_EvaluationFormQuestionCriterion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EvaluationFormQuestionCriterion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EvaluationFormQuestions_CriterionId",
                table: "Tbl_EvaluationFormQuestions",
                column: "CriterionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_EvaluationFormQuestions_Tbl_EvaluationFormQuestionCriterion_CriterionId",
                table: "Tbl_EvaluationFormQuestions",
                column: "CriterionId",
                principalTable: "Tbl_EvaluationFormQuestionCriterion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
