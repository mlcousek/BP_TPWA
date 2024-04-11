using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class upravaklicuvtreninkovedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreninkoveData_Cvik_CvikId",
                table: "TreninkoveData");

            migrationBuilder.DropIndex(
                name: "IX_TreninkoveData_CvikId",
                table: "TreninkoveData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TreninkoveData_CvikId",
                table: "TreninkoveData",
                column: "CvikId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreninkoveData_Cvik_CvikId",
                table: "TreninkoveData",
                column: "CvikId",
                principalTable: "Cvik",
                principalColumn: "CvikId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
