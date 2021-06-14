using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationSystem.Infra.DAL.SQL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Colleges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Colleges", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Tbl_EvaluationIndex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EvaluationIndex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGroup = table.Column<byte>(type: "TinyInt", nullable: false),
                    CollegeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Users_Tbl_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Tbl_Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EvaluationForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EvaluationIndexId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EvaluationForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_EvaluationForms_Tbl_EvaluationIndex_EvaluationIndexId",
                        column: x => x.EvaluationIndexId,
                        principalTable: "Tbl_EvaluationIndex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EvaluationIndexCollegeWeight",
                columns: table => new
                {
                    EvaluationIndexId = table.Column<int>(type: "int", nullable: false),
                    CollegeId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EvaluationIndexCollegeWeight", x => new { x.CollegeId, x.EvaluationIndexId });
                    table.ForeignKey(
                        name: "FK_Tbl_EvaluationIndexCollegeWeight_Tbl_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Tbl_Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_EvaluationIndexCollegeWeight_Tbl_EvaluationIndex_EvaluationIndexId",
                        column: x => x.EvaluationIndexId,
                        principalTable: "Tbl_EvaluationIndex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserAccessToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserAccessToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_UserAccessToken_Tbl_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EvaluationFormQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriterionId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<byte>(type: "tinyint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Weight = table.Column<byte>(type: "tinyint", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EvaluationFormQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_EvaluationFormQuestions_Tbl_EvaluationFormQuestionCriterion_CriterionId",
                        column: x => x.CriterionId,
                        principalTable: "Tbl_EvaluationFormQuestionCriterion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_EvaluationFormQuestions_Tbl_EvaluationForms_FormId",
                        column: x => x.FormId,
                        principalTable: "Tbl_EvaluationForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EvaluationFormAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    OrderId = table.Column<byte>(type: "tinyint", nullable: false),
                    WeightPercent = table.Column<byte>(type: "tinyint", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EvaluationFormAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_EvaluationFormAnswers_Tbl_EvaluationFormQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Tbl_EvaluationFormQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EvaluationFormAnswers_QuestionId",
                table: "Tbl_EvaluationFormAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EvaluationFormQuestions_CriterionId",
                table: "Tbl_EvaluationFormQuestions",
                column: "CriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EvaluationFormQuestions_FormId",
                table: "Tbl_EvaluationFormQuestions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EvaluationForms_EvaluationIndexId",
                table: "Tbl_EvaluationForms",
                column: "EvaluationIndexId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EvaluationIndexCollegeWeight_EvaluationIndexId",
                table: "Tbl_EvaluationIndexCollegeWeight",
                column: "EvaluationIndexId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserAccessToken_UserId",
                table: "Tbl_UserAccessToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NationCode",
                table: "Tbl_Users",
                column: "NationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Users_CollegeId",
                table: "Tbl_Users",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserName",
                table: "Tbl_Users",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_EvaluationFormAnswers");

            migrationBuilder.DropTable(
                name: "Tbl_EvaluationIndexCollegeWeight");

            migrationBuilder.DropTable(
                name: "Tbl_UserAccessToken");

            migrationBuilder.DropTable(
                name: "Tbl_EvaluationFormQuestions");

            migrationBuilder.DropTable(
                name: "Tbl_Users");

            migrationBuilder.DropTable(
                name: "Tbl_EvaluationFormQuestionCriterion");

            migrationBuilder.DropTable(
                name: "Tbl_EvaluationForms");

            migrationBuilder.DropTable(
                name: "Tbl_Colleges");

            migrationBuilder.DropTable(
                name: "Tbl_EvaluationIndex");
        }
    }
}
