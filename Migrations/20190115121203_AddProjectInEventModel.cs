using Microsoft.EntityFrameworkCore.Migrations;

namespace teamWcrh.Migrations
{
    public partial class AddProjectInEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ProjectId",
                table: "Events",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Projects_ProjectId",
                table: "Events",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Projects_ProjectId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ProjectId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Events");
        }
    }
}
