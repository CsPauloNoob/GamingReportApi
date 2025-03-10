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
                    Score = table.Column<decimal>(type: "TEXT", nullable: false),
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
                    { "b9c3b167-ece2-4736-aadd-b89d82c4208c", "Developer Two" },
                    { "e1bdd499-bfc0-4f56-b6e0-5c33c6c60f59", "Developer One" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "DeveloperId", "Name", "Platform" },
                values: new object[,]
                {
                    { "56af6d7c-dc58-44ce-95b8-58b11ccedbc7", "Description for Game One", "e1bdd499-bfc0-4f56-b6e0-5c33c6c60f59", "Game One", "[0,2]" },
                    { "dbb0f2e5-5f2b-474d-8cec-ebef7e9b14fb", "Description for Game Two", "b9c3b167-ece2-4736-aadd-b89d82c4208c", "Game Two", "[1,3]" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "DownPoints", "GameId", "Score", "Title", "UpPoints" },
                values: new object[,]
                {
                    { "10a9521d-fdeb-4ebd-ab05-c6a980a65f88", "Content for Review Two", 1, "dbb0f2e5-5f2b-474d-8cec-ebef7e9b14fb", 9.0m, "Review Two", 15 },
                    { "7d98a023-dc95-4496-91d8-10da9d708fe3", "Content for Review One", 2, "56af6d7c-dc58-44ce-95b8-58b11ccedbc7", 8.5m, "Review One", 10 }
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
