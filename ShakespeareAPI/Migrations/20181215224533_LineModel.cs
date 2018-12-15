using Microsoft.EntityFrameworkCore.Migrations;

namespace ShakespeareAPI.Migrations
{
    public partial class LineModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Character",
                table: "Lines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterLineNumber",
                table: "Lines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Character",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "CharacterLineNumber",
                table: "Lines");
        }
    }
}
