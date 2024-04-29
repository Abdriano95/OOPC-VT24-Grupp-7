using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilverkstad.Datalager.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMekanikerWithBokningar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MekanikerId",
                table: "Bokning",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bokning_MekanikerId",
                table: "Bokning",
                column: "MekanikerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bokning_Anställd_MekanikerId",
                table: "Bokning",
                column: "MekanikerId",
                principalTable: "Anställd",
                principalColumn: "AnställningsNummer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bokning_Anställd_MekanikerId",
                table: "Bokning");

            migrationBuilder.DropIndex(
                name: "IX_Bokning_MekanikerId",
                table: "Bokning");

            migrationBuilder.DropColumn(
                name: "MekanikerId",
                table: "Bokning");
        }
    }
}
