using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelancingApp.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class JobsUpdate_Payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Jobs",
                newName: "PaymentAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentAmount",
                table: "Jobs",
                newName: "Price");
        }
    }
}
