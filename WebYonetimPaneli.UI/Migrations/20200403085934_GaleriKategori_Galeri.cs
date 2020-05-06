using Microsoft.EntityFrameworkCore.Migrations;

namespace WebYonetimPaneli.UI.Migrations
{
    public partial class GaleriKategori_Galeri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaleriKategori",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaleriKategori", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Galeri",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(nullable: true),
                    Aciklama = table.Column<string>(nullable: true),
                    GaleriKategoriID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galeri", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Galeri_GaleriKategori_GaleriKategoriID",
                        column: x => x.GaleriKategoriID,
                        principalTable: "GaleriKategori",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Galeri_GaleriKategoriID",
                table: "Galeri",
                column: "GaleriKategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galeri");

            migrationBuilder.DropTable(
                name: "GaleriKategori");
        }
    }
}
