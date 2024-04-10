using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class migrace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DenVTydnu_TP_TPId",
                table: "DenVTydnu");

            migrationBuilder.AddForeignKey(
                name: "FK_DenVTydnu_TP_TPId",
                table: "DenVTydnu",
                column: "TPId",
                principalTable: "TP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DenVTydnu_TP_TPId",
                table: "DenVTydnu");

            migrationBuilder.AddForeignKey(
                name: "FK_DenVTydnu_TP_TPId",
                table: "DenVTydnu",
                column: "TPId",
                principalTable: "TP",
                principalColumn: "Id");
        }
    }
}
