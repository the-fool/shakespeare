using Microsoft.EntityFrameworkCore.Migrations;

namespace ShakespeareAPI.Migrations
{
    public partial class AddToLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActNumber",
                table: "Lines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LineNumber",
                table: "Lines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SceneNumber",
                table: "Lines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Lines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActNumber",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "LineNumber",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "SceneNumber",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Lines");
        }
    }
}
