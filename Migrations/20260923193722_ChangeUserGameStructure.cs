using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutbolcuKimApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserGameStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_DailyGames_DailyGameId",
                table: "UserGames");

            migrationBuilder.DropIndex(
                name: "IX_UserGames_DailyGameId",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "DailyGameId",
                table: "UserGames");

            migrationBuilder.AddColumn<DateTime>(
                name: "GameDate",
                table: "UserGames",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameDate",
                table: "UserGames");

            migrationBuilder.AddColumn<int>(
                name: "DailyGameId",
                table: "UserGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_DailyGameId",
                table: "UserGames",
                column: "DailyGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_DailyGames_DailyGameId",
                table: "UserGames",
                column: "DailyGameId",
                principalTable: "DailyGames",
                principalColumn: "Id");
        }
    }
}
