using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilverkstad.Datalager.Migrations
{
    /// <inheritdoc />
    public partial class EntityUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bokning_Anställd_ReceptionistAnställningsNummer",
                table: "Bokning");

            migrationBuilder.DropForeignKey(
                name: "FK_Bokning_Kund_KundId",
                table: "Bokning");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparation_Anställd_MekanikerAnställningsNummer",
                table: "Reparation");

            migrationBuilder.AlterColumn<int>(
                name: "MekanikerAnställningsNummer",
                table: "Reparation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReceptionistAnställningsNummer",
                table: "Bokning",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KundId",
                table: "Bokning",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bokning_Anställd_ReceptionistAnställningsNummer",
                table: "Bokning",
                column: "ReceptionistAnställningsNummer",
                principalTable: "Anställd",
                principalColumn: "AnställningsNummer");

            migrationBuilder.AddForeignKey(
                name: "FK_Bokning_Kund_KundId",
                table: "Bokning",
                column: "KundId",
                principalTable: "Kund",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparation_Anställd_MekanikerAnställningsNummer",
                table: "Reparation",
                column: "MekanikerAnställningsNummer",
                principalTable: "Anställd",
                principalColumn: "AnställningsNummer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bokning_Anställd_ReceptionistAnställningsNummer",
                table: "Bokning");

            migrationBuilder.DropForeignKey(
                name: "FK_Bokning_Kund_KundId",
                table: "Bokning");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparation_Anställd_MekanikerAnställningsNummer",
                table: "Reparation");

            migrationBuilder.AlterColumn<int>(
                name: "MekanikerAnställningsNummer",
                table: "Reparation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReceptionistAnställningsNummer",
                table: "Bokning",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KundId",
                table: "Bokning",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bokning_Anställd_ReceptionistAnställningsNummer",
                table: "Bokning",
                column: "ReceptionistAnställningsNummer",
                principalTable: "Anställd",
                principalColumn: "AnställningsNummer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bokning_Kund_KundId",
                table: "Bokning",
                column: "KundId",
                principalTable: "Kund",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparation_Anställd_MekanikerAnställningsNummer",
                table: "Reparation",
                column: "MekanikerAnställningsNummer",
                principalTable: "Anställd",
                principalColumn: "AnställningsNummer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
