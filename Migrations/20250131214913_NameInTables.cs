using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_VideoGamesConsoles.Migrations
{
    /// <inheritdoc />
    public partial class NameInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.CreateTable(
                name: "GameConsoles",
                columns: table => new
                {
                    GameConsoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Teraflops = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsoles", x => x.GameConsoleID);
                    table.ForeignKey(
                        name: "FK_GameConsoles_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameConsoles_BrandID",
                table: "GameConsoles",
                column: "BrandID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameConsoles");

            migrationBuilder.CreateTable(
                name: "Consoles",
                columns: table => new
                {
                    ConsoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teraflops = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consoles", x => x.ConsoleID);
                    table.ForeignKey(
                        name: "FK_Consoles_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consoles_BrandID",
                table: "Consoles",
                column: "BrandID");
        }
    }
}
