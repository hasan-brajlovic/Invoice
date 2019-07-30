using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Migracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Fid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojFakture = table.Column<string>(type: "varchar(16)", nullable: false),
                    Datum = table.Column<string>(type: "varchar(10)", nullable: false),
                    Dobavljac = table.Column<string>(type: "varchar(50)", nullable: false),
                    Adresa = table.Column<string>(type: "varchar(100)", nullable: false),
                    CijenaFakture = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Fid);
                });

            migrationBuilder.CreateTable(
                name: "Stavke",
                columns: table => new
                {
                    Sid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojFakture = table.Column<string>(type: "varchar(16)", nullable: false),
                    RedniBrojStavke = table.Column<int>(nullable: false),
                    SifraArtikla = table.Column<string>(type: "varchar(10)", nullable: true),
                    NazivArtikla = table.Column<string>(type: "varchar(50)", nullable: true),
                    Kolicina = table.Column<int>(nullable: false),
                    JedinicnaCijena = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stavke", x => x.Sid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Stavke");
        }
    }
}
