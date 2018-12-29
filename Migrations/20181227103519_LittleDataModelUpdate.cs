using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace teamWcrh.Migrations
{
    public partial class LittleDataModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "skill",
                table: "JoinRequests",
                newName: "Skill");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "JoinRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "JoinRequests",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "JoinRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "JoinRequests");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "JoinRequests");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "JoinRequests");

            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "JoinRequests",
                newName: "skill");
        }
    }
}
