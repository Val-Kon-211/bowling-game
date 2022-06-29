using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class PlayerShots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lastP1HitX",
                table: "GameSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lastP1HitY",
                table: "GameSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lastP2HitX",
                table: "GameSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lastP2HitY",
                table: "GameSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "playerTurn",
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

            migrationBuilder.AddColumn<int>(
                name: "winner",
                table: "GameSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastP1HitX",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "lastP1HitY",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "lastP2HitX",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "lastP2HitY",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "playerTurn",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "started",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "winner",
                table: "GameSessions");
        }
    }
}
