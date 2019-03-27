using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HostOcean.Persistence.Migrations
{
    public partial class RegistrationStartedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationStartedAt",
                table: "LaboratoryWorkEvents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationStartedAt",
                table: "LaboratoryWorkEvents");
        }
    }
}
