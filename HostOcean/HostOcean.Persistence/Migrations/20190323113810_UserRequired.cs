using Microsoft.EntityFrameworkCore.Migrations;

namespace HostOcean.Persistence.Migrations
{
    public partial class UserRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQueues_AspNetUsers_UserId",
                table: "UserQueues");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQueues_AspNetUsers_UserId",
                table: "UserQueues",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQueues_AspNetUsers_UserId",
                table: "UserQueues");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQueues_AspNetUsers_UserId",
                table: "UserQueues",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
