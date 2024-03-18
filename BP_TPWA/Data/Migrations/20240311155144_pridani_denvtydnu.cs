using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class pridani_denvtydnu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DenVTydnu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Den = table.Column<int>(type: "int", nullable: false),
                    DenTréninku = table.Column<bool>(type: "bit", nullable: false),
                    TypTreninku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TPId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenVTydnu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DenVTydnu_TP_TPId",
                        column: x => x.TPId,
                        principalTable: "TP",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DenVTydnu_TPId",
                table: "DenVTydnu",
                column: "TPId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DenVTydnu");
        }
    }
}
