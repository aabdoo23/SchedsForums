using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedsForums.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class forums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    Guidelines = table.Column<string[]>(type: "text[]", nullable: true),
                    ForumType = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: true),
                    FacultyId = table.Column<Guid>(type: "uuid", nullable: true),
                    MajorId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forums_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forums_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forums_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forums_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumModerators",
                columns: table => new
                {
                    ModeratedForumsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModeratorsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumModerators", x => new { x.ModeratedForumsId, x.ModeratorsId });
                    table.ForeignKey(
                        name: "FK_ForumModerators_Forums_ModeratedForumsId",
                        column: x => x.ModeratedForumsId,
                        principalTable: "Forums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForumModerators_Users_ModeratorsId",
                        column: x => x.ModeratorsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumSubscriptions",
                columns: table => new
                {
                    SubscribedForumsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscribedUsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumSubscriptions", x => new { x.SubscribedForumsId, x.SubscribedUsersId });
                    table.ForeignKey(
                        name: "FK_ForumSubscriptions_Forums_SubscribedForumsId",
                        column: x => x.SubscribedForumsId,
                        principalTable: "Forums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForumSubscriptions_Users_SubscribedUsersId",
                        column: x => x.SubscribedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumModerators_ModeratorsId",
                table: "ForumModerators",
                column: "ModeratorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Forums_CourseId",
                table: "Forums",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Forums_CreatedById",
                table: "Forums",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Forums_FacultyId",
                table: "Forums",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Forums_MajorId",
                table: "Forums",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumSubscriptions_SubscribedUsersId",
                table: "ForumSubscriptions",
                column: "SubscribedUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumModerators");

            migrationBuilder.DropTable(
                name: "ForumSubscriptions");

            migrationBuilder.DropTable(
                name: "Forums");
        }
    }
}
