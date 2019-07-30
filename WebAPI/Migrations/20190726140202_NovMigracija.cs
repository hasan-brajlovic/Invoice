using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class NovMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_InvoiceDetails_BrojFakture",
                table: "Stavke");

            migrationBuilder.DropIndex(
                name: "IX_Stavke_BrojFakture",
                table: "Stavke");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceDetails",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "Fid",
                table: "Stavke",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fid",
                table: "InvoiceDetails",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceDetails",
                table: "InvoiceDetails",
                column: "Fid");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_Fid",
                table: "Stavke",
                column: "Fid");

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_InvoiceDetails_Fid",
                table: "Stavke",
                column: "Fid",
                principalTable: "InvoiceDetails",
                principalColumn: "Fid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_InvoiceDetails_Fid",
                table: "Stavke");

            migrationBuilder.DropIndex(
                name: "IX_Stavke_Fid",
                table: "Stavke");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceDetails",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Fid",
                table: "Stavke");

            migrationBuilder.DropColumn(
                name: "Fid",
                table: "InvoiceDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceDetails",
                table: "InvoiceDetails",
                column: "BrojFakture");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_BrojFakture",
                table: "Stavke",
                column: "BrojFakture");

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_InvoiceDetails_BrojFakture",
                table: "Stavke",
                column: "BrojFakture",
                principalTable: "InvoiceDetails",
                principalColumn: "BrojFakture",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
