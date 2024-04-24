using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class znenanapomocneDatum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DenZalozeniUctu",
                table: "AspNetUsers",
                newName: "PomocneDatum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PomocneDatum",
                table: "AspNetUsers",
                newName: "DenZalozeniUctu");
        }
    }
}
