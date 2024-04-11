using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class zmenyupravaklicutreninkoveData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreninkoveData_AspNetUsers_UzivatelId",
                table: "TreninkoveData");

            migrationBuilder.DropIndex(
                name: "IX_TreninkoveData_UzivatelId",
                table: "TreninkoveData");

            migrationBuilder.AlterColumn<string>(
                name: "UzivatelId",
                table: "TreninkoveData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreninkoveData_Cvik_CvikId",
                table: "TreninkoveData");

            migrationBuilder.DropIndex(
                name: "IX_TreninkoveData_CvikId",
                table: "TreninkoveData");

            migrationBuilder.AlterColumn<string>(
                name: "UzivatelId",
                table: "TreninkoveData",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TreninkoveData_UzivatelId",
                table: "TreninkoveData",
                column: "UzivatelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreninkoveData_AspNetUsers_UzivatelId",
                table: "TreninkoveData",
                column: "UzivatelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
