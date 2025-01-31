using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_VideoGamesConsoles.Migrations
{
    /// <inheritdoc />
    public partial class teraflopsInConsole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Teraflops",
                table: "Consoles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Teraflops",
                table: "Consoles");
        }
    }
}
