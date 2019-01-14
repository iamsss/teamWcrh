using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace teamWcrh.Migrations
{
    public partial class UpdateUserGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalForUserId",
                table: "UserGoal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedOn",
                table: "UserGoal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "UserGoal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "UserGoal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalForUserId",
                table: "UserGoal");

            migrationBuilder.DropColumn(
                name: "JoinedOn",
                table: "UserGoal");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "UserGoal");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserGoal");
        }
    }
}
