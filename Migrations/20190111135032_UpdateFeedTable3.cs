using Microsoft.EntityFrameworkCore.Migrations;

namespace teamWcrh.Migrations
{
    public partial class UpdateFeedTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelatedProjectId",
                table: "Feeds",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Feeds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_ProjectId",
                table: "Feeds",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_UserId",
                table: "Feeds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Projects_ProjectId",
                table: "Feeds",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Users_UserId",
                table: "Feeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Projects_ProjectId",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Users_UserId",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_ProjectId",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_UserId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Feeds");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Feeds",
                newName: "RelatedProjectId");
        }
    }
}
