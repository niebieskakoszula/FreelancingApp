using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelancingApp.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class CurrenciesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrencySymbol",
                table: "Currencies",
                newName: "Symbol");

            migrationBuilder.RenameColumn(
                name: "CurrencyName",
                table: "Currencies",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "Currencies",
                newName: "CurrencySymbol");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Currencies",
                newName: "CurrencyName");
        }
    }
}
