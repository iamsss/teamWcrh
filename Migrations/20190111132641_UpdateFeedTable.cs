using Microsoft.EntityFrameworkCore.Migrations;

namespace teamWcrh.Migrations
{
    public partial class UpdateFeedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeedPic",
                table: "Feeds",
                newName: "FeedUserPic");

            migrationBuilder.AddColumn<int>(
                name: "relatedProjectId",
                table: "Feeds",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "relatedProjectId",
                table: "Feeds");

            migrationBuilder.RenameColumn(
                name: "FeedUserPic",
                table: "Feeds",
                newName: "FeedPic");
        }
    }
}
