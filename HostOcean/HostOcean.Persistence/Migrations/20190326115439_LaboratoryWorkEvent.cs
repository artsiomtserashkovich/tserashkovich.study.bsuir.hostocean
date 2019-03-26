using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HostOcean.Persistence.Migrations
{
    public partial class LaboratoryWorkEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Queues_LaboratoryWorks_FK_Laboratory_Work",
                table: "Queues");

            migrationBuilder.DropIndex(
                name: "IX_Queues_FK_Laboratory_Work",
                table: "Queues");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryWorks_GroupId",
                table: "LaboratoryWorks");

            migrationBuilder.DropColumn(
                name: "FK_Laboratory_Work",
                table: "Queues");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "LaboratoryWorks");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "LaboratoryWorks");

            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "Queues",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "LaboratoryWorks",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lecturer",
                table: "LaboratoryWorks",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LaboratoryWorkEvents",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    LaboratoryWorkId = table.Column<string>(nullable: false),
                    QueueId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryWorkEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryWorkEvents_LaboratoryWorks_LaboratoryWorkId",
                        column: x => x.LaboratoryWorkId,
                        principalTable: "LaboratoryWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaboratoryWorkEvents_Queues_QueueId",
                        column: x => x.QueueId,
                        principalTable: "Queues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryWorks_GroupId_Lecturer_Title",
                table: "LaboratoryWorks",
                columns: new[] { "GroupId", "Lecturer", "Title" },
                unique: true,
                filter: "[Lecturer] IS NOT NULL AND [Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryWorkEvents_LaboratoryWorkId",
                table: "LaboratoryWorkEvents",
                column: "LaboratoryWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryWorkEvents_QueueId",
                table: "LaboratoryWorkEvents",
                column: "QueueId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaboratoryWorkEvents");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryWorks_GroupId_Lecturer_Title",
                table: "LaboratoryWorks");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Queues");

            migrationBuilder.AddColumn<string>(
                name: "FK_Laboratory_Work",
                table: "Queues",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "LaboratoryWorks",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lecturer",
                table: "LaboratoryWorks",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "LaboratoryWorks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "LaboratoryWorks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Queues_FK_Laboratory_Work",
                table: "Queues",
                column: "FK_Laboratory_Work",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryWorks_GroupId",
                table: "LaboratoryWorks",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Queues_LaboratoryWorks_FK_Laboratory_Work",
                table: "Queues",
                column: "FK_Laboratory_Work",
                principalTable: "LaboratoryWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
