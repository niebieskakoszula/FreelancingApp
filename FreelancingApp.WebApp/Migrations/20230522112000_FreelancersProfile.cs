using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelancingApp.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class FreelancersProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Contacts_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_AspNetUsers_AppUserId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Experiences",
                newName: "FreelancerId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_AppUserId",
                table: "Experiences",
                newName: "IX_Experiences_FreelancerId");

            migrationBuilder.AddColumn<string>(
                name: "FreelancerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Freelancers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FreelancerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelancers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Freelancers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FreelancerId",
                table: "AspNetUsers",
                column: "FreelancerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_ContactId",
                table: "Freelancers",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Freelancers_FreelancerId",
                table: "AspNetUsers",
                column: "FreelancerId",
                principalTable: "Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Freelancers_FreelancerId",
                table: "Experiences",
                column: "FreelancerId",
                principalTable: "Freelancers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Freelancers_FreelancerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Freelancers_FreelancerId",
                table: "Experiences");

            migrationBuilder.DropTable(
                name: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FreelancerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FreelancerId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FreelancerId",
                table: "Experiences",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_FreelancerId",
                table: "Experiences",
                newName: "IX_Experiences_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ContactId",
                table: "AspNetUsers",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Contacts_ContactId",
                table: "AspNetUsers",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_AspNetUsers_AppUserId",
                table: "Experiences",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
