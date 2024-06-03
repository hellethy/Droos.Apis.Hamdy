using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Droos.Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    ChapterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.ChapterId);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    McqId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DurationInSeconds = table.Column<int>(type: "int", nullable: true),
                    IsFree = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    URL = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    HtmlText = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ContentId);
                });

            migrationBuilder.CreateTable(
                name: "EducationSystems",
                columns: table => new
                {
                    EducationSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationSystem_1", x => x.EducationSystemId);
                });

            migrationBuilder.CreateTable(
                name: "ExamTemplate",
                columns: table => new
                {
                    ExamTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTemplate", x => x.ExamTemplateId);
                });

            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    GovernorateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.GovernorateId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionContents",
                columns: table => new
                {
                    SectionContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionContent", x => x.SectionContentId);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChapterContents",
                columns: table => new
                {
                    ChapterContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ChapterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterContent", x => x.ChapterContentId);
                    table.ForeignKey(
                        name: "FK_ChapterContent_Chapter",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "ChapterId");
                    table.ForeignKey(
                        name: "FK_ChapterContent_Content",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "ContentId");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    ItemType = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riview", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Contents",
                        column: x => x.ItemId,
                        principalTable: "Contents",
                        principalColumn: "ContentId");
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ExamTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Result = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Exam_ExamTemplate",
                        column: x => x.ExamTemplateId,
                        principalTable: "ExamTemplate",
                        principalColumn: "ExamTemplateId");
                });

            migrationBuilder.CreateTable(
                name: "QuestionTemplate",
                columns: table => new
                {
                    QuestionTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ExamTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTemplate", x => x.QuestionTemplateId);
                    table.ForeignKey(
                        name: "FK_QuestionTemplate_ExamTemplate",
                        column: x => x.ExamTemplateId,
                        principalTable: "ExamTemplate",
                        principalColumn: "ExamTemplateId");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GovernorateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grade_EducationSystem",
                        column: x => x.EducationSystemId,
                        principalTable: "EducationSystems",
                        principalColumn: "EducationSystemId");
                    table.ForeignKey(
                        name: "FK_Grade_Governorate",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "GovernorateId");
                });

            migrationBuilder.CreateTable(
                name: "SectionChapters",
                columns: table => new
                {
                    SectionChapterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChapterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionChapters", x => x.SectionChapterId);
                    table.ForeignKey(
                        name: "FK_SectionChapters_Chapters",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "ChapterId");
                    table.ForeignKey(
                        name: "FK_SectionChapters_Sections",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId");
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    QuestionTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnswerTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answer_Exam",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "ExamId");
                    table.ForeignKey(
                        name: "FK_Answer_QuestionTemplate",
                        column: x => x.QuestionTemplateId,
                        principalTable: "QuestionTemplate",
                        principalColumn: "QuestionTemplateId");
                });

            migrationBuilder.CreateTable(
                name: "AnswersTemplate",
                columns: table => new
                {
                    AnswerTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true),
                    QuestionTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersTemplate", x => x.AnswerTemplateId);
                    table.ForeignKey(
                        name: "FK_AnswersTemplate_QuestionTemplate",
                        column: x => x.QuestionTemplateId,
                        principalTable: "QuestionTemplate",
                        principalColumn: "QuestionTemplateId");
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subject_Grade",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId");
                });

            migrationBuilder.CreateTable(
                name: "PayableItem",
                columns: table => new
                {
                    PayableItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PayableItemType = table.Column<int>(type: "int", nullable: true),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChapterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ValidFor = table.Column<int>(type: "int", nullable: true),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayableItem", x => x.PayableItemId);
                    table.ForeignKey(
                        name: "FK_PayableItem_Chapters",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "ChapterId");
                    table.ForeignKey(
                        name: "FK_PayableItem_Contents",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "ContentId");
                    table.ForeignKey(
                        name: "FK_PayableItem_Sections",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId");
                    table.ForeignKey(
                        name: "FK_PayableItem_Subjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateTable(
                name: "SubjectSections",
                columns: table => new
                {
                    SubjectSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectSections", x => x.SubjectSectionId);
                    table.ForeignKey(
                        name: "FK_SubjectSections_Sections",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId");
                    table.ForeignKey(
                        name: "FK_SubjectSections_Subject",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SubscriptionOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionType = table.Column<int>(type: "int", nullable: true),
                    PaymentConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    PayableItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentConfirmedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                    table.ForeignKey(
                        name: "FK_Subscriptions_PayableItem",
                        column: x => x.PayableItemId,
                        principalTable: "PayableItem",
                        principalColumn: "PayableItemId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_ExamId",
                table: "Answer",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionTemplateId",
                table: "Answer",
                column: "QuestionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswersTemplate_QuestionTemplateId",
                table: "AnswersTemplate",
                column: "QuestionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterContents_ChapterId",
                table: "ChapterContents",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterContents_ContentId",
                table: "ChapterContents",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ExamTemplateId",
                table: "Exam",
                column: "ExamTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_EducationSystemId",
                table: "Grades",
                column: "EducationSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_GovernorateId",
                table: "Grades",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableItem_ChapterId",
                table: "PayableItem",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableItem_ContentId",
                table: "PayableItem",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableItem_SectionId",
                table: "PayableItem",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableItem_SubjectId",
                table: "PayableItem",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTemplate_ExamTemplateId",
                table: "QuestionTemplate",
                column: "ExamTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ItemId",
                table: "Review",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionChapters_ChapterId",
                table: "SectionChapters",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionChapters_SectionId",
                table: "SectionChapters",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_GradeId",
                table: "Subjects",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSections_SectionId",
                table: "SubjectSections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSections_SubjectId",
                table: "SubjectSections",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_PayableItemId",
                table: "Subscriptions",
                column: "PayableItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "AnswersTemplate");

            migrationBuilder.DropTable(
                name: "ChapterContents");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SectionChapters");

            migrationBuilder.DropTable(
                name: "SectionContents");

            migrationBuilder.DropTable(
                name: "SubjectSections");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "QuestionTemplate");

            migrationBuilder.DropTable(
                name: "PayableItem");

            migrationBuilder.DropTable(
                name: "ExamTemplate");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "EducationSystems");

            migrationBuilder.DropTable(
                name: "Governorates");
        }
    }
}
