using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class den_treninku1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TPId",
                table: "DenTreninku",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DenTreninku_TPId",
                table: "DenTreninku",
                column: "TPId");

            migrationBuilder.AddForeignKey(
                name: "FK_DenTreninku_TP_TPId",
                table: "DenTreninku",
                column: "TPId",
                principalTable: "TP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DenTreninku_TP_TPId",
                table: "DenTreninku");

            migrationBuilder.DropIndex(
                name: "IX_DenTreninku_TPId",
                table: "DenTreninku");

            migrationBuilder.DropColumn(
                name: "TPId",
                table: "DenTreninku");
        }
    }
}
