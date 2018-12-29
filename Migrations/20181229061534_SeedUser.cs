using Microsoft.EntityFrameworkCore.Migrations;

namespace teamWcrh.Migrations
{
    public partial class SeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Users (Name, Username, Password,Rp,Cp,UserRole,PrimaryOccupation,SecondaryOccupation) VALUES ('Saurav','saurav','qwert12345',150,150,'admin','Web Developer','Android Developer')");
            migrationBuilder.Sql("INSERT INTO Users (Name, Username, Password,Rp,Cp,UserRole,PrimaryOccupation,SecondaryOccupation) VALUES ('Joy','joy','qwert12345',150,150,'member','Android Developer', 'Blogger' )");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users");
        }
    }
}
