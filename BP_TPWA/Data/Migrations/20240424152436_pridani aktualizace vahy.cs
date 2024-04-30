using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class pridaniaktualizacevahy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JakCastoAktualizovatVahu",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JakCastoAktualizovatVahu",
                table: "AspNetUsers");
        }
    }
}
