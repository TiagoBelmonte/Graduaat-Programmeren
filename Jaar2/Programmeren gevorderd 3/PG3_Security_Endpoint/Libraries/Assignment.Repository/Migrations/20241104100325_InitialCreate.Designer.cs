﻿// <auto-generated />
using System;
using Assignment.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment.Repository.Migrations
{
    [DbContext(typeof(CarwashContext))]
    [Migration("20241104100325_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment.Repository.Models.Bestellingen", b =>
                {
                    b.Property<int>("BestellingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BestellingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BestellingId"));

                    b.Property<DateOnly>("BestelDatum")
                        .HasColumnType("date");

                    b.Property<int>("KlantId")
                        .HasColumnType("int")
                        .HasColumnName("KlantID");

                    b.Property<decimal>("TotaalBedrag")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("VoertuigId")
                        .HasColumnType("int")
                        .HasColumnName("VoertuigID");

                    b.HasKey("BestellingId")
                        .HasName("PK__Bestelli__2326A2855070BC68");

                    b.HasIndex("KlantId");

                    b.HasIndex("VoertuigId");

                    b.ToTable("Bestellingen", (string)null);
                });

            modelBuilder.Entity("Assignment.Repository.Models.Bestellingsregel", b =>
                {
                    b.Property<int>("BestellingsregelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BestellingsregelID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BestellingsregelId"));

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.Property<int>("BestellingId")
                        .HasColumnType("int")
                        .HasColumnName("BestellingID");

                    b.Property<int>("DienstId")
                        .HasColumnType("int")
                        .HasColumnName("DienstID");

                    b.Property<decimal>("PrijsPerStuk")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("TotaalPrijs")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("BestellingsregelId")
                        .HasName("PK__Bestelli__D80E112E65C9A690");

                    b.HasIndex("BestellingId");

                    b.HasIndex("DienstId");

                    b.ToTable("Bestellingsregels");
                });

            modelBuilder.Entity("Assignment.Repository.Models.Diensten", b =>
                {
                    b.Property<int>("DienstId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DienstID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DienstId"));

                    b.Property<string>("Beschrijving")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("DienstId")
                        .HasName("PK__Diensten__509D81CBB819BC83");

                    b.ToTable("Diensten", (string)null);
                });

            modelBuilder.Entity("Assignment.Repository.Models.Klanten", b =>
                {
                    b.Property<int>("KlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KlantID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KlantId"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefoon")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("KlantId")
                        .HasName("PK__Klanten__A2633BE2E3A27848");

                    b.ToTable("Klanten", (string)null);
                });

            modelBuilder.Entity("Assignment.Repository.Models.Voertuigen", b =>
                {
                    b.Property<int>("VoertuigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VoertuigID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoertuigId"));

                    b.Property<string>("Kenteken")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("KlantId")
                        .HasColumnType("int")
                        .HasColumnName("KlantID");

                    b.Property<string>("Merk")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("VoertuigId")
                        .HasName("PK__Voertuig__ABAE50DBD62054A4");

                    b.HasIndex("KlantId");

                    b.ToTable("Voertuigen", (string)null);
                });

            modelBuilder.Entity("Assignment.Repository.Models.Bestellingen", b =>
                {
                    b.HasOne("Assignment.Repository.Models.Klanten", "Klant")
                        .WithMany("Bestellingens")
                        .HasForeignKey("KlantId")
                        .IsRequired()
                        .HasConstraintName("FK__Bestellin__Klant__3E52440B");

                    b.HasOne("Assignment.Repository.Models.Voertuigen", "Voertuig")
                        .WithMany("Bestellingens")
                        .HasForeignKey("VoertuigId")
                        .IsRequired()
                        .HasConstraintName("FK__Bestellin__Voert__3F466844");

                    b.Navigation("Klant");

                    b.Navigation("Voertuig");
                });

            modelBuilder.Entity("Assignment.Repository.Models.Bestellingsregel", b =>
                {
                    b.HasOne("Assignment.Repository.Models.Bestellingen", "Bestelling")
                        .WithMany("Bestellingsregels")
                        .HasForeignKey("BestellingId")
                        .IsRequired()
                        .HasConstraintName("FK__Bestellin__Beste__4222D4EF");

                    b.HasOne("Assignment.Repository.Models.Diensten", "Dienst")
                        .WithMany("Bestellingsregels")
                        .HasForeignKey("DienstId")
                        .IsRequired()
                        .HasConstraintName("FK__Bestellin__Diens__4316F928");

                    b.Navigation("Bestelling");

                    b.Navigation("Dienst");
                });

            modelBuilder.Entity("Assignment.Repository.Models.Voertuigen", b =>
                {
                    b.HasOne("Assignment.Repository.Models.Klanten", "Klant")
                        .WithMany("Voertuigens")
                        .HasForeignKey("KlantId")
                        .IsRequired()
                        .HasConstraintName("FK__Voertuige__Klant__398D8EEE");

                    b.Navigation("Klant");
                });

            modelBuilder.Entity("Assignment.Repository.Models.Bestellingen", b =>
                {
                    b.Navigation("Bestellingsregels");
                });

            modelBuilder.Entity("Assignment.Repository.Models.Diensten", b =>
                {
                    b.Navigation("Bestellingsregels");
                });

            modelBuilder.Entity("Assignment.Repository.Models.Klanten", b =>
                {
                    b.Navigation("Bestellingens");

                    b.Navigation("Voertuigens");
                });

            modelBuilder.Entity("Assignment.Repository.Models.Voertuigen", b =>
                {
                    b.Navigation("Bestellingens");
                });
#pragma warning restore 612, 618
        }
    }
}
