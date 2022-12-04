using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterSheetAPI.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Character_Background",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Character_Class",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Character_Race",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Character_Background",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Character_Class",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Character_Race",
                table: "Characters");
        }
    }
}
