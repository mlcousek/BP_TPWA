using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class odebraniicollectioncviky : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cvik_DenTreninku_DenTreninkuId",
                table: "Cvik");

            migrationBuilder.DropIndex(
                name: "IX_Cvik_DenTreninkuId",
                table: "Cvik");

            migrationBuilder.DropColumn(
                name: "DenTreninkuId",
                table: "Cvik");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DenTreninkuId",
                table: "Cvik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cvik_DenTreninkuId",
                table: "Cvik",
                column: "DenTreninkuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cvik_DenTreninku_DenTreninkuId",
                table: "Cvik",
                column: "DenTreninkuId",
                principalTable: "DenTreninku",
                principalColumn: "Id");
        }
    }
}
