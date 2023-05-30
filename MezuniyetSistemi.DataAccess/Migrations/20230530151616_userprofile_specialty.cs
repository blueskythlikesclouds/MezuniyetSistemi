using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MezuniyetSistemi.DataAccess.Migrations
{
    public partial class userprofile_specialty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Specialties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_UserProfileId",
                table: "Specialties",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_UserProfiles_UserProfileId",
                table: "Specialties",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_UserProfiles_UserProfileId",
                table: "Specialties");

            migrationBuilder.DropIndex(
                name: "IX_Specialties_UserProfileId",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Specialties");
        }
    }
}
