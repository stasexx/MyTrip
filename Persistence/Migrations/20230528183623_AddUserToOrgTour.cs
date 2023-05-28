using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToOrgTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OrgTours",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrgTours_UserId",
                table: "OrgTours",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgTours_Users_UserId",
                table: "OrgTours",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrgTours_Users_UserId",
                table: "OrgTours");

            migrationBuilder.DropIndex(
                name: "IX_OrgTours_UserId",
                table: "OrgTours");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrgTours");
        }
    }
}
