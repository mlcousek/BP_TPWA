using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class TP_add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Délka = table.Column<int>(type: "int", nullable: false),
                    DruhTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StylTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ÚroveňTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UzivatelID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TP_AspNetUsers_UzivatelID",
                        column: x => x.UzivatelID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TP_UzivatelID",
                table: "TP",
                column: "UzivatelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TP");
        }
    }
}
