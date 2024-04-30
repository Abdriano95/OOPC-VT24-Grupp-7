using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilverkstad.Datalager.Migrations
{
    /// <inheritdoc />
    public partial class configurerepbo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparation_Bokning_BokningId",
                table: "Reparation");

            migrationBuilder.DropTable(
                name: "ReparationReservdel");

            migrationBuilder.DropIndex(
                name: "IX_Reparation_BokningId",
                table: "Reparation");

            migrationBuilder.DropColumn(
                name: "BokningId",
                table: "Reparation");

            migrationBuilder.AddColumn<int>(
                name: "ReservdelId",
                table: "Reparation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reparation_BokningsId",
                table: "Reparation",
                column: "BokningsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparation_ReservdelId",
                table: "Reparation",
                column: "ReservdelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparation_Bokning_BokningsId",
                table: "Reparation",
                column: "BokningsId",
                principalTable: "Bokning",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparation_Reservdel_ReservdelId",
                table: "Reparation",
                column: "ReservdelId",
                principalTable: "Reservdel",
                principalColumn: "Artikelnummer",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparation_Bokning_BokningsId",
                table: "Reparation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparation_Reservdel_ReservdelId",
                table: "Reparation");

            migrationBuilder.DropIndex(
                name: "IX_Reparation_BokningsId",
                table: "Reparation");

            migrationBuilder.DropIndex(
                name: "IX_Reparation_ReservdelId",
                table: "Reparation");

            migrationBuilder.DropColumn(
                name: "ReservdelId",
                table: "Reparation");

            migrationBuilder.AddColumn<int>(
                name: "BokningId",
                table: "Reparation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReparationReservdel",
                columns: table => new
                {
                    ReparationId = table.Column<int>(type: "int", nullable: false),
                    ReservdelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReparationReservdel", x => new { x.ReparationId, x.ReservdelId });
                    table.ForeignKey(
                        name: "FK_ReparationReservdel_Reparation_ReparationId",
                        column: x => x.ReparationId,
                        principalTable: "Reparation",
                        principalColumn: "ReparationsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReparationReservdel_Reservdel_ReservdelId",
                        column: x => x.ReservdelId,
                        principalTable: "Reservdel",
                        principalColumn: "Artikelnummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reparation_BokningId",
                table: "Reparation",
                column: "BokningId");

            migrationBuilder.CreateIndex(
                name: "IX_ReparationReservdel_ReservdelId",
                table: "ReparationReservdel",
                column: "ReservdelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparation_Bokning_BokningId",
                table: "Reparation",
                column: "BokningId",
                principalTable: "Bokning",
                principalColumn: "Id");
        }
    }
}
