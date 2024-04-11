using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class zoufalstvi3699 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UzivatelId",
                table: "Cvik",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Cvik_UzivatelId",
                table: "Cvik",
                column: "UzivatelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cvik_AspNetUsers_UzivatelId",
                table: "Cvik",
                column: "UzivatelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cvik_AspNetUsers_UzivatelId",
                table: "Cvik");

            migrationBuilder.DropIndex(
                name: "IX_Cvik_UzivatelId",
                table: "Cvik");

            migrationBuilder.AlterColumn<string>(
                name: "UzivatelId",
                table: "Cvik",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
