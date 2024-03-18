using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class pridani_cviku_controlleru : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cvik",
                columns: table => new
                {
                    CvikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Název = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PočetOpakování = table.Column<int>(type: "int", nullable: false),
                    PočetSérií = table.Column<int>(type: "int", nullable: false),
                    PauzaMeziSériemi = table.Column<int>(type: "int", nullable: false),
                    PopisCviku = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cvik", x => x.CvikId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cvik");
        }
    }
}
