using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MezuniyetSistemi.DataAccess.Migrations
{
    public partial class userprofile_company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserProfileId",
                table: "Companies",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_UserProfiles_UserProfileId",
                table: "Companies",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_UserProfiles_UserProfileId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_UserProfileId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Companies");
        }
    }
}
