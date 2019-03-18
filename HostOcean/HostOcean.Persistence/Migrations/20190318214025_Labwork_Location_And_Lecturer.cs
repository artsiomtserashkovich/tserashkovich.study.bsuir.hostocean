using Microsoft.EntityFrameworkCore.Migrations;

namespace HostOcean.Persistence.Migrations
{
    public partial class Labwork_Location_And_Lecturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lecturer",
                table: "LaboratoryWorks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "LaboratoryWorks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lecturer",
                table: "LaboratoryWorks");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "LaboratoryWorks");
        }
    }
}
