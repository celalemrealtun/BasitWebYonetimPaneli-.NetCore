using Microsoft.EntityFrameworkCore.Migrations;

namespace WebYonetimPaneli.UI.Migrations
{
    public partial class SiteAyarIletisim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Iletisim",
                table: "SiteAyar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iletisim",
                table: "SiteAyar");
        }
    }
}
