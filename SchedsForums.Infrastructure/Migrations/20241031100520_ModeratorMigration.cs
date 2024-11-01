using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedsForums.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModeratorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "Users",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(8)",
                oldMaxLength: 8);

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedById",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModeratorSignUpRequestId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PendingModerators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeratorSignUpRequests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApprovedById",
                table: "Users",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModeratorSignUpRequestId",
                table: "Users",
                column: "ModeratorSignUpRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ModeratorSignUpRequests_ModeratorSignUpRequestId",
                table: "Users",
                column: "ModeratorSignUpRequestId",
                principalTable: "PendingModerators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ApprovedById",
                table: "Users",
                column: "ApprovedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ModeratorSignUpRequests_ModeratorSignUpRequestId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ApprovedById",
                table: "Users");

            migrationBuilder.DropTable(
                name: "PendingModerators");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApprovedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ModeratorSignUpRequestId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModeratorSignUpRequestId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "Users",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(13)",
                oldMaxLength: 13);
        }
    }
}
