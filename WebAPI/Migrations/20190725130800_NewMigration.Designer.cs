﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations
{
    [DbContext(typeof(InvoiceDetailContext))]
    [Migration("20190725130800_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.InvoiceDetail", b =>
                {
                    b.Property<string>("BrojFakture")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<double>("CijenaFakture");

                    b.Property<string>("Datum")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Dobavljac")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("BrojFakture");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("WebAPI.Models.Stavke", b =>
                {
                    b.Property<int>("Sid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojFakture")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<double>("JedinicnaCijena");

                    b.Property<int>("Kolicina");

                    b.Property<string>("NazivArtikla")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("RedniBrojStavke");

                    b.Property<string>("SifraArtikla")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Sid");

                    b.HasIndex("BrojFakture");

                    b.ToTable("Stavke");
                });

            modelBuilder.Entity("WebAPI.Models.Stavke", b =>
                {
                    b.HasOne("WebAPI.Models.InvoiceDetail", "Faktura")
                        .WithMany("Stavke")
                        .HasForeignKey("BrojFakture")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
