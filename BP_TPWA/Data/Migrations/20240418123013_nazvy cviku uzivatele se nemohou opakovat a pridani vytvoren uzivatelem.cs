using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class nazvycvikuuzivatelesenemohouopakovatapridanivytvorenuzivatelem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Název",
                table: "Cvik",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "cvikVytvorenUzivatelem",
                table: "Cvik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Cvik_Název_UzivatelId",
                table: "Cvik",
                columns: new[] { "Název", "UzivatelId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cvik_Název_UzivatelId",
                table: "Cvik");

            migrationBuilder.DropColumn(
                name: "cvikVytvorenUzivatelem",
                table: "Cvik");

            migrationBuilder.AlterColumn<string>(
                name: "Název",
                table: "Cvik",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
