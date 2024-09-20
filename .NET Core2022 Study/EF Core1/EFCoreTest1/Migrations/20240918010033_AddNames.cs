using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTest1.Migrations
{
    public partial class AddNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Names",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Authors");
        }
    }
}
