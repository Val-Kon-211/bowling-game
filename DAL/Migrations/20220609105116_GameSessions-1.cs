using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class GameSessions1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "started",
                table: "GameSessions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "started",
                table: "GameSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
