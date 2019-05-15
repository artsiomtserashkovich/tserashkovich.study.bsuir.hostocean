using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HostOcean.Persistence.Migrations
{
    public partial class Add_Requests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatorUserId = table.Column<string>(nullable: true),
                    ReceiverUserId = table.Column<string>(nullable: true),
                    QueueId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_ReceiverUserId",
                        column: x => x.ReceiverUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CreatorUserId",
                table: "Requests",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ReceiverUserId",
                table: "Requests",
                column: "ReceiverUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
