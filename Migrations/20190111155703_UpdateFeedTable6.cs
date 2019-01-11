using Microsoft.EntityFrameworkCore.Migrations;

namespace teamWcrh.Migrations
{
    public partial class UpdateFeedTable6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Projects_ProjectId",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Users_UserId",
                table: "Feeds");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Feeds",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Feeds",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Feeds",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_EventId",
                table: "Feeds",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Events_EventId",
                table: "Feeds",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Projects_ProjectId",
                table: "Feeds",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Users_UserId",
                table: "Feeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Events_EventId",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Projects_ProjectId",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Users_UserId",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_EventId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Feeds");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Feeds",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Feeds",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
