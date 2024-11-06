using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.CreateTable(
                name: "Diensten",
                columns: table => new
                {
                    DienstID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Prijs = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Diensten__509D81CBB819BC83", x => x.DienstID);
                });

            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    KlantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefoon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Klanten__A2633BE2E3A27848", x => x.KlantID);
                });

            migrationBuilder.CreateTable(
                name: "Voertuigen",
                columns: table => new
                {
                    VoertuigID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantID = table.Column<int>(type: "int", nullable: false),
                    Kenteken = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Merk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Voertuig__ABAE50DBD62054A4", x => x.VoertuigID);
                    table.ForeignKey(
                        name: "FK__Voertuige__Klant__398D8EEE",
                        column: x => x.KlantID,
                        principalTable: "Klanten",
                        principalColumn: "KlantID");
                });

            migrationBuilder.CreateTable(
                name: "Bestellingen",
                columns: table => new
                {
                    BestellingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantID = table.Column<int>(type: "int", nullable: false),
                    VoertuigID = table.Column<int>(type: "int", nullable: false),
                    BestelDatum = table.Column<DateOnly>(type: "date", nullable: false),
                    TotaalBedrag = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bestelli__2326A2855070BC68", x => x.BestellingID);
                    table.ForeignKey(
                        name: "FK__Bestellin__Klant__3E52440B",
                        column: x => x.KlantID,
                        principalTable: "Klanten",
                        principalColumn: "KlantID");
                    table.ForeignKey(
                        name: "FK__Bestellin__Voert__3F466844",
                        column: x => x.VoertuigID,
                        principalTable: "Voertuigen",
                        principalColumn: "VoertuigID");
                });

            migrationBuilder.CreateTable(
                name: "Bestellingsregels",
                columns: table => new
                {
                    BestellingsregelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BestellingID = table.Column<int>(type: "int", nullable: false),
                    DienstID = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false),
                    PrijsPerStuk = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TotaalPrijs = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bestelli__D80E112E65C9A690", x => x.BestellingsregelID);
                    table.ForeignKey(
                        name: "FK__Bestellin__Beste__4222D4EF",
                        column: x => x.BestellingID,
                        principalTable: "Bestellingen",
                        principalColumn: "BestellingID");
                    table.ForeignKey(
                        name: "FK__Bestellin__Diens__4316F928",
                        column: x => x.DienstID,
                        principalTable: "Diensten",
                        principalColumn: "DienstID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_KlantID",
                table: "Bestellingen",
                column: "KlantID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_VoertuigID",
                table: "Bestellingen",
                column: "VoertuigID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingsregels_BestellingID",
                table: "Bestellingsregels",
                column: "BestellingID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingsregels_DienstID",
                table: "Bestellingsregels",
                column: "DienstID");

            migrationBuilder.CreateIndex(
                name: "IX_Voertuigen_KlantID",
                table: "Voertuigen",
                column: "KlantID");
            */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bestellingsregels");

            migrationBuilder.DropTable(
                name: "Bestellingen");

            migrationBuilder.DropTable(
                name: "Diensten");

            migrationBuilder.DropTable(
                name: "Voertuigen");

            migrationBuilder.DropTable(
                name: "Klanten");
        }
    }
}
