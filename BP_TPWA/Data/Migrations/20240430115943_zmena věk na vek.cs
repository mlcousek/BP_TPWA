using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class zmenavěknavek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Věk",
                table: "AspNetUsers",
                newName: "Vek");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vek",
                table: "AspNetUsers",
                newName: "Věk");
        }
    }
}
