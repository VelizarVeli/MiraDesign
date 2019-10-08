using Microsoft.EntityFrameworkCore.Migrations;

namespace MiraDesign.Data.Migrations
{
    public partial class NameForImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Images",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Images");
        }
    }
}
