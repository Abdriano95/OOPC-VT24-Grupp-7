using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilverkstad.Datalager.Migrations
{
    /// <inheritdoc />
    public partial class Bilverkstad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anställd",
                columns: table => new
                {
                    AnställningsNummer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yrkesroll = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lösenord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Specialiseringar = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anställd", x => x.AnställningsNummer);
                });

            migrationBuilder.CreateTable(
                name: "Kund",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatuadress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Epost = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kund", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fordon",
                columns: table => new
                {
                    RegNr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bilmärke = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fordon", x => x.RegNr);
                    table.ForeignKey(
                        name: "FK_Fordon_Kund_KundId",
                        column: x => x.KundId,
                        principalTable: "Kund",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bokning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KundId = table.Column<int>(type: "int", nullable: false),
                    FordonRegNr = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReceptionistAnställningsNummer = table.Column<int>(type: "int", nullable: false),
                    InlämningsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtlämningsDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SyfteMedBesök = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bokning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bokning_Anställd_ReceptionistAnställningsNummer",
                        column: x => x.ReceptionistAnställningsNummer,
                        principalTable: "Anställd",
                        principalColumn: "AnställningsNummer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bokning_Fordon_FordonRegNr",
                        column: x => x.FordonRegNr,
                        principalTable: "Fordon",
                        principalColumn: "RegNr");
                    table.ForeignKey(
                        name: "FK_Bokning_Kund_KundId",
                        column: x => x.KundId,
                        principalTable: "Kund",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reparation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BokningId = table.Column<int>(type: "int", nullable: true),
                    MekanikerAnställningsNummer = table.Column<int>(type: "int", nullable: false),
                    Åtgärd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reparation_Anställd_MekanikerAnställningsNummer",
                        column: x => x.MekanikerAnställningsNummer,
                        principalTable: "Anställd",
                        principalColumn: "AnställningsNummer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reparation_Bokning_BokningId",
                        column: x => x.BokningId,
                        principalTable: "Bokning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservdel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pris = table.Column<float>(type: "real", nullable: false),
                    ReparationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservdel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservdel_Reparation_ReparationId",
                        column: x => x.ReparationId,
                        principalTable: "Reparation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bokning_FordonRegNr",
                table: "Bokning",
                column: "FordonRegNr");

            migrationBuilder.CreateIndex(
                name: "IX_Bokning_KundId",
                table: "Bokning",
                column: "KundId");

            migrationBuilder.CreateIndex(
                name: "IX_Bokning_ReceptionistAnställningsNummer",
                table: "Bokning",
                column: "ReceptionistAnställningsNummer");

            migrationBuilder.CreateIndex(
                name: "IX_Fordon_KundId",
                table: "Fordon",
                column: "KundId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparation_BokningId",
                table: "Reparation",
                column: "BokningId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparation_MekanikerAnställningsNummer",
                table: "Reparation",
                column: "MekanikerAnställningsNummer");

            migrationBuilder.CreateIndex(
                name: "IX_Reservdel_ReparationId",
                table: "Reservdel",
                column: "ReparationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservdel");

            migrationBuilder.DropTable(
                name: "Reparation");

            migrationBuilder.DropTable(
                name: "Bokning");

            migrationBuilder.DropTable(
                name: "Anställd");

            migrationBuilder.DropTable(
                name: "Fordon");

            migrationBuilder.DropTable(
                name: "Kund");
        }
    }
}
