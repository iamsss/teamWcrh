using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace teamWcrh.Migrations
{
    public partial class ReturnToInitialStageOfModelGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Targets");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "Goals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Goals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
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

            migrationBuilder.AlterColumn<string>(
                name: "Deadline",
                table: "Goals",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedOn",
                table: "Goals",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    TargetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<string>(nullable: true),
                    Deadline = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GoalFor = table.Column<string>(nullable: true),
                    GoalType = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PriorityLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.TargetId);
                });
        }
    }
}
