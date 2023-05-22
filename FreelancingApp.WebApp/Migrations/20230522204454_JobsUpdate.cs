using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelancingApp.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class JobsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Freelancers_FreelancerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_Contacts_ContactId",
                table: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_Freelancers_ContactId",
                table: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FreelancerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "FreelancerId",
                table: "Freelancers");

            migrationBuilder.RenameColumn(
                name: "SkillName",
                table: "Skills",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Proficiency",
                table: "Experiences",
                newName: "Level");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHourly",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Freelancers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FreelancerId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_AppUserId",
                table: "Freelancers",
                column: "AppUserId",
                unique: true);

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
                name: "FK_Freelancers_AspNetUsers_AppUserId",
                table: "Freelancers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Contacts_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_AspNetUsers_AppUserId",
                table: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_Freelancers_AppUserId",
                table: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsHourly",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Skills",
                newName: "SkillName");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Experiences",
                newName: "Proficiency");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Freelancers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreelancerId",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FreelancerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_ContactId",
                table: "Freelancers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FreelancerId",
                table: "AspNetUsers",
                column: "FreelancerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Freelancers_FreelancerId",
                table: "AspNetUsers",
                column: "FreelancerId",
                principalTable: "Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_Contacts_ContactId",
                table: "Freelancers",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }
    }
}
