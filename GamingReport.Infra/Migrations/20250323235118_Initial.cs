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
                    DeveloperId = table.Column<string>(type: "TEXT", nullable: false),
                    SteamGameId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    { "27835279-e7d2-40e7-9e6d-184d4d57040d", "Developer Two" },
                    { "d973f564-472b-49b0-bd5f-0c71da721886", "Developer One" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "DeveloperId", "Name", "Platform", "SteamGameId" },
                values: new object[,]
                {
                    { "da6e8206-b0c4-46cc-a2ba-26d0681b4a2c", "Description for Game One", "d973f564-472b-49b0-bd5f-0c71da721886", "Game One", "[0,2]", 0 },
                    { "e0a62d44-8293-4cdc-86f0-eca8bbea2493", "Description for Game Two", "27835279-e7d2-40e7-9e6d-184d4d57040d", "Game Two", "[1,3]", 0 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "CreatedAt", "DownPoints", "GameId", "GamePlatform", "Score", "Title", "UpPoints" },
                values: new object[,]
                {
                    { "6cf306d3-aa7c-498f-b84a-5f72d148e7fb", "Content for Review One", new DateTime(2025, 3, 23, 18, 51, 18, 649, DateTimeKind.Local).AddTicks(3223), 2, "da6e8206-b0c4-46cc-a2ba-26d0681b4a2c", 0, 8.5m, "Review One", 10 },
                    { "72a1728a-d172-44c8-967c-58745268f0b9", "Content for Review Two", new DateTime(2025, 3, 23, 18, 51, 18, 649, DateTimeKind.Local).AddTicks(3235), 1, "e0a62d44-8293-4cdc-86f0-eca8bbea2493", 0, 9.0m, "Review Two", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Name",
                table: "Games",
                column: "Name",
                unique: true);

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
