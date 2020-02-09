using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCoreSlika.Migrations
{
    public partial class Druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipFajla",
                table: "Slika",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipFajla",
                table: "Slika");
        }
    }
}
