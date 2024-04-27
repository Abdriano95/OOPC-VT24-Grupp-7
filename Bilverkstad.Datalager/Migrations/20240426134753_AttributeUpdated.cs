using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilverkstad.Datalager.Migrations
{
    /// <inheritdoc />
    public partial class AttributeUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservdel_Reparation_ReparationId",
                table: "Reservdel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reparation",
                table: "Reparation");

            migrationBuilder.RenameColumn(
                name: "ReparationId",
                table: "Reservdel",
                newName: "ReparationsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservdel",
                newName: "Artikelnummer");

            migrationBuilder.RenameIndex(
                name: "IX_Reservdel_ReparationId",
                table: "Reservdel",
                newName: "IX_Reservdel_ReparationsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reparation",
                newName: "Reparationsstatus");

            migrationBuilder.AlterColumn<int>(
                name: "Reparationsstatus",
                table: "Reparation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ReparationsId",
                table: "Reparation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reparation",
                table: "Reparation",
                column: "ReparationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservdel_Reparation_ReparationsId",
                table: "Reservdel",
                column: "ReparationsId",
                principalTable: "Reparation",
                principalColumn: "ReparationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservdel_Reparation_ReparationsId",
                table: "Reservdel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reparation",
                table: "Reparation");

            migrationBuilder.DropColumn(
                name: "ReparationsId",
                table: "Reparation");

            migrationBuilder.RenameColumn(
                name: "ReparationsId",
                table: "Reservdel",
                newName: "ReparationId");

            migrationBuilder.RenameColumn(
                name: "Artikelnummer",
                table: "Reservdel",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reservdel_ReparationsId",
                table: "Reservdel",
                newName: "IX_Reservdel_ReparationId");

            migrationBuilder.RenameColumn(
                name: "Reparationsstatus",
                table: "Reparation",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reparation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reparation",
                table: "Reparation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservdel_Reparation_ReparationId",
                table: "Reservdel",
                column: "ReparationId",
                principalTable: "Reparation",
                principalColumn: "Id");
        }
    }
}
