using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class uprava_typtreninku : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypTreninku",
                table: "DenVTydnu");

            migrationBuilder.AddColumn<string>(
                name: "TypTreninku",
                table: "DenTreninku",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypTreninku",
                table: "DenTreninku");

            migrationBuilder.AddColumn<string>(
                name: "TypTreninku",
                table: "DenVTydnu",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
