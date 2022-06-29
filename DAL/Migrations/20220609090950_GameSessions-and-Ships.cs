using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class GameSessionsandShips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoseCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WinCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "finished",
                table: "GameSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "p1Hits",
                table: "GameSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "p1HitsForWin",
                table: "GameSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "p2Hits",
                table: "GameSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "p2HitsForWin",
                table: "GameSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "started",
                table: "GameSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PlayerShips",
                columns: table => new
                {
                    gameSessionId = table.Column<int>(type: "int", nullable: false),
                    player = table.Column<int>(type: "int", nullable: false),
                    x = table.Column<int>(type: "int", nullable: false),
                    y = table.Column<int>(type: "int", nullable: false),
                    hit = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerShips", x => new { x.gameSessionId, x.player, x.x, x.y });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerShips");

            migrationBuilder.DropColumn(
                name: "LoseCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WinCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "finished",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "p1Hits",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "p1HitsForWin",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "p2Hits",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "p2HitsForWin",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "started",
                table: "GameSessions");
        }
    }
}
