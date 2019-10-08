using Microsoft.EntityFrameworkCore.Migrations;

namespace MiraDesign.Data.Migrations
{
    public partial class SubnameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subname",
                table: "Projects",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subname",
                table: "Projects");
        }
    }
}
