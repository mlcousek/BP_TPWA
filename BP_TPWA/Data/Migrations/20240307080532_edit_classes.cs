using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class edit_classes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ÚroveňTP",
                table: "TP");

            migrationBuilder.AddColumn<string>(
                name: "Úroveň",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Úroveň",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ÚroveňTP",
                table: "TP",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
