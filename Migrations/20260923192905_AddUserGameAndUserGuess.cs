using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutbolcuKimApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserGameAndUserGuess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DailyGameId = table.Column<int>(type: "int", nullable: false),
                    GuessCount = table.Column<int>(type: "int", nullable: false),
                    IsWon = table.Column<bool>(type: "bit", nullable: false),
                    PlayedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGames_DailyGames_DailyGameId",
                        column: x => x.DailyGameId,
                        principalTable: "DailyGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGuesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGameId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    GuessNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGuesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGuesses_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGuesses_UserGames_UserGameId",
                        column: x => x.UserGameId,
                        principalTable: "UserGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_DailyGameId",
                table: "UserGames",
                column: "DailyGameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGuesses_PlayerId",
                table: "UserGuesses",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGuesses_UserGameId",
                table: "UserGuesses",
                column: "UserGameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGuesses");

            migrationBuilder.DropTable(
                name: "UserGames");
        }
    }
}
