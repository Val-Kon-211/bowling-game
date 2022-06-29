using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class LobbySessionRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Started",
                table: "OpenGames");

            migrationBuilder.AddColumn<int>(
                name: "sessionID",
                table: "OpenGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lobbyID",
                table: "GameSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sessionID",
                table: "OpenGames");

            migrationBuilder.DropColumn(
                name: "lobbyID",
                table: "GameSessions");

            migrationBuilder.AddColumn<bool>(
                name: "Started",
                table: "OpenGames",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
