using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class mazani_den_v_treninku : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DenTreninku");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DenTreninku",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzivatelID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Den = table.Column<int>(type: "int", nullable: false),
                    DenTréninku = table.Column<bool>(type: "bit", nullable: false),
                    TPId = table.Column<int>(type: "int", nullable: true),
                    TypTreninku = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenTreninku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DenTreninku_AspNetUsers_UzivatelID",
                        column: x => x.UzivatelID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DenTreninku_TP_TPId",
                        column: x => x.TPId,
                        principalTable: "TP",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DenTreninku_TPId",
                table: "DenTreninku",
                column: "TPId");

            migrationBuilder.CreateIndex(
                name: "IX_DenTreninku_UzivatelID",
                table: "DenTreninku",
                column: "UzivatelID");
        }
    }
}
