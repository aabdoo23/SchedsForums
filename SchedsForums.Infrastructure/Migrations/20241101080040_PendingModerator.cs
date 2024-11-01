using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedsForums.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PendingModerator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ModeratorSignUpRequestId",
                table: "Users",
                newName: "StatusUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ModeratorSignUpRequestId",
                table: "Users",
                newName: "IX_Users_StatusUpdatedById");

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "Users",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(13)",
                oldMaxLength: 13);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusUpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_StatusUpdatedById",
                table: "Users",
                column: "StatusUpdatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_StatusUpdatedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StatusUpdatedAt",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StatusUpdatedById",
                table: "Users",
                newName: "ModeratorSignUpRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_StatusUpdatedById",
                table: "Users",
                newName: "IX_Users_ModeratorSignUpRequestId");

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "Users",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(21)",
                oldMaxLength: 21);

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedById",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PendingModerators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeratorSignUpRequests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApprovedById",
                table: "Users",
                column: "ApprovedById");

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
    }
}
