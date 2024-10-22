using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedsForums.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Majors_MajorId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropIndex(
                name: "IX_Users_MajorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "MajorId",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MajorId",
                table: "Users",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Majors_MajorId",
                table: "Users",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id");
        }
    }
}
