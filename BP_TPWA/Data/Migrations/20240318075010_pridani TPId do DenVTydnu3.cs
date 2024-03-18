using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class pridaniTPIddoDenVTydnu3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DenVTydnu_TP_TPId",
                table: "DenVTydnu");

            migrationBuilder.AlterColumn<int>(
                name: "TPId",
                table: "DenVTydnu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "TPId",
                table: "DenVTydnu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DenVTydnu_TP_TPId",
                table: "DenVTydnu",
                column: "TPId",
                principalTable: "TP",
                principalColumn: "Id");
        }
    }
}
