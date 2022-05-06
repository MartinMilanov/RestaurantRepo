using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Data.Migrations
{
    public partial class AddedLogsTableAndLastEditedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastEdited18118164",
                schema: "18118164",
                table: "Tables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEdited18118164",
                schema: "18118164",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEdited18118164",
                schema: "18118164",
                table: "Foods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEdited18118164",
                schema: "18118164",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEdited18118164",
                schema: "18118164",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Logs_18118164",
                schema: "18118164",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAndTimeOfOperation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdited18118164 = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs_18118164", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs_18118164",
                schema: "18118164");

            migrationBuilder.DropColumn(
                name: "LastEdited18118164",
                schema: "18118164",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "LastEdited18118164",
                schema: "18118164",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LastEdited18118164",
                schema: "18118164",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "LastEdited18118164",
                schema: "18118164",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastEdited18118164",
                schema: "18118164",
                table: "Bills");
        }
    }
}
