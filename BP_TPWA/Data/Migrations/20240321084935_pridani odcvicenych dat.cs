using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class pridaniodcvicenychdat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreninkoveData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzivatelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CvikId = table.Column<int>(type: "int", nullable: false),
                    PocetSerii = table.Column<int>(type: "int", nullable: false),
                    PocetOpakovani = table.Column<int>(type: "int", nullable: false),
                    CvicenaVaha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreninkoveData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreninkoveData_AspNetUsers_UzivatelId",
                        column: x => x.UzivatelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreninkoveData_Cvik_CvikId",
                        column: x => x.CvikId,
                        principalTable: "Cvik",
                        principalColumn: "CvikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreninkoveData_CvikId",
                table: "TreninkoveData",
                column: "CvikId");

            migrationBuilder.CreateIndex(
                name: "IX_TreninkoveData_UzivatelId",
                table: "TreninkoveData",
                column: "UzivatelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreninkoveData");
        }
    }
}
