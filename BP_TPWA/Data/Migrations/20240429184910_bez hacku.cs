using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class bezhacku : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Název",
                table: "Cvik",
                newName: "Nazev");

            migrationBuilder.RenameIndex(
                name: "IX_Cvik_Název_UzivatelId",
                table: "Cvik",
                newName: "IX_Cvik_Nazev_UzivatelId");

            migrationBuilder.RenameColumn(
                name: "Úroveň",
                table: "AspNetUsers",
                newName: "Vyska");

            migrationBuilder.RenameColumn(
                name: "Výška",
                table: "AspNetUsers",
                newName: "Uroven");

            migrationBuilder.RenameColumn(
                name: "Váha",
                table: "AspNetUsers",
                newName: "Vaha");

            migrationBuilder.RenameColumn(
                name: "Příjmení",
                table: "AspNetUsers",
                newName: "Prijmeni");

            migrationBuilder.RenameColumn(
                name: "Pohlaví",
                table: "AspNetUsers",
                newName: "Pohlavi");

            migrationBuilder.RenameColumn(
                name: "Jméno",
                table: "AspNetUsers",
                newName: "Jmeno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nazev",
                table: "Cvik",
                newName: "Název");

            migrationBuilder.RenameIndex(
                name: "IX_Cvik_Nazev_UzivatelId",
                table: "Cvik",
                newName: "IX_Cvik_Název_UzivatelId");

            migrationBuilder.RenameColumn(
                name: "Vyska",
                table: "AspNetUsers",
                newName: "Úroveň");

            migrationBuilder.RenameColumn(
                name: "Vaha",
                table: "AspNetUsers",
                newName: "Váha");

            migrationBuilder.RenameColumn(
                name: "Uroven",
                table: "AspNetUsers",
                newName: "Výška");

            migrationBuilder.RenameColumn(
                name: "Prijmeni",
                table: "AspNetUsers",
                newName: "Příjmení");

            migrationBuilder.RenameColumn(
                name: "Pohlavi",
                table: "AspNetUsers",
                newName: "Pohlaví");

            migrationBuilder.RenameColumn(
                name: "Jmeno",
                table: "AspNetUsers",
                newName: "Jméno");
        }
    }
}
