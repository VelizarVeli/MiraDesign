using Microsoft.EntityFrameworkCore.Migrations;

namespace MiraDesign.Data.Migrations
{
    public partial class Images1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Images",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Link",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
