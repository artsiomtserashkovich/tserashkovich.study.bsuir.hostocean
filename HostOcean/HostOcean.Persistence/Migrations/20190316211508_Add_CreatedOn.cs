using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HostOcean.Persistence.Migrations
{
    public partial class Add_CreatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserQueues_QueueId_Order",
                table: "UserQueues");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "UserQueues");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserQueues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserQueues");

            migrationBuilder.AddColumn<short>(
                name: "Order",
                table: "UserQueues",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_UserQueues_QueueId_Order",
                table: "UserQueues",
                columns: new[] { "QueueId", "Order" },
                unique: true);
        }
    }
}
