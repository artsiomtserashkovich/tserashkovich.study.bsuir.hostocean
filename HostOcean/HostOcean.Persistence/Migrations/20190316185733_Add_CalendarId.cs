using Microsoft.EntityFrameworkCore.Migrations;

namespace HostOcean.Persistence.Migrations
{
    public partial class Add_CalendarId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CalendarId",
                table: "Groups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalendarId",
                table: "Groups");
        }
    }
}
