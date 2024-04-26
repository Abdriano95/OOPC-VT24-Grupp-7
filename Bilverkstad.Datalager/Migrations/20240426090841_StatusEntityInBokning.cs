using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilverkstad.Datalager.Migrations
{
    /// <inheritdoc />
    public partial class StatusEntityInBokning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Yrkesroll",
                table: "Anställd");

            migrationBuilder.AddColumn<int>(
                name: "BokningStatus",
                table: "Bokning",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Auktoritet",
                table: "Anställd",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BokningStatus",
                table: "Bokning");

            migrationBuilder.DropColumn(
                name: "Auktoritet",
                table: "Anställd");

            migrationBuilder.AddColumn<string>(
                name: "Yrkesroll",
                table: "Anställd",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
