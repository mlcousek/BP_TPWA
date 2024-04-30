using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class testovaci_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PridaneTestovaciData",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PridaneTestovaciData",
                table: "AspNetUsers");
        }
    }
}
