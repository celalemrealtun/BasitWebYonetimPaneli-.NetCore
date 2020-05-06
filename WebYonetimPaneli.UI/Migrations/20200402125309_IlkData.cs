using Microsoft.EntityFrameworkCore.Migrations;

namespace WebYonetimPaneli.UI.Migrations
{
    public partial class IlkData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteAyar",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteLogo = table.Column<string>(nullable: true),
                    SiteAdi = table.Column<string>(nullable: true),
                    SiteAnahtar = table.Column<string>(nullable: true),
                    SiteAciklama = table.Column<string>(nullable: true),
                    SiteURL = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    HaritaKonum = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    OrtaBaslik = table.Column<string>(nullable: true),
                    OrtaIcerik = table.Column<string>(nullable: true),
                    Hakkimizda = table.Column<string>(nullable: true),
                    VizyonMisyon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteAyar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(nullable: true),
                    Icerik = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    KayitSilindi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteAyar");

            migrationBuilder.DropTable(
                name: "Slider");
        }
    }
}
