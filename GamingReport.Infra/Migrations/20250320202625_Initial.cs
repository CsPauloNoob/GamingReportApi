using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamingReport.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Platform = table.Column<string>(type: "TEXT", nullable: false),
                    DeveloperId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Score = table.Column<decimal>(type: "TEXT", nullable: false),
                    GamePlatform = table.Column<int>(type: "INTEGER", nullable: false),
                    UpPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    DownPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    GameId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "04edaa65-cd88-41dd-9388-0e12e9d53123", "Developer Two" },
                    { "f77b48d0-d04d-43cc-9138-be13a43f24e4", "Developer One" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "DeveloperId", "Name", "Platform" },
                values: new object[,]
                {
                    { "2244383b-50d4-47aa-96c1-d1a59ecf47d9", "Description for Game One", "f77b48d0-d04d-43cc-9138-be13a43f24e4", "Game One", "[0,2]" },
                    { "95354d6e-9e98-4f07-a60c-984b6051948f", "Description for Game Two", "04edaa65-cd88-41dd-9388-0e12e9d53123", "Game Two", "[1,3]" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "CreatedAt", "DownPoints", "GameId", "GamePlatform", "Score", "Title", "UpPoints" },
                values: new object[,]
                {
                    { "085b2794-d434-4acf-9bee-2b476906fd1f", "Content for Review One", new DateTime(2025, 3, 20, 16, 26, 25, 450, DateTimeKind.Local).AddTicks(631), 2, "2244383b-50d4-47aa-96c1-d1a59ecf47d9", 0, 8.5m, "Review One", 10 },
                    { "39617810-2fc0-4845-8ee6-c53b1f19d343", "Content for Review Two", new DateTime(2025, 3, 20, 16, 26, 25, 450, DateTimeKind.Local).AddTicks(689), 1, "95354d6e-9e98-4f07-a60c-984b6051948f", 0, 9.0m, "Review Two", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_GameId",
                table: "Reviews",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Developers");
        }
    }
}
