using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Data.Migrations
{
    public partial class OnDelLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Tables_TableId",
                schema: "18118164",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                schema: "18118164",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableId",
                schema: "18118164",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Tables_TableId",
                schema: "18118164",
                table: "Bills",
                column: "TableId",
                principalSchema: "18118164",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                schema: "18118164",
                table: "Foods",
                column: "CategoryId",
                principalSchema: "18118164",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableId",
                schema: "18118164",
                table: "Reservations",
                column: "TableId",
                principalSchema: "18118164",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Tables_TableId",
                schema: "18118164",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                schema: "18118164",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableId",
                schema: "18118164",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Tables_TableId",
                schema: "18118164",
                table: "Bills",
                column: "TableId",
                principalSchema: "18118164",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                schema: "18118164",
                table: "Foods",
                column: "CategoryId",
                principalSchema: "18118164",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableId",
                schema: "18118164",
                table: "Reservations",
                column: "TableId",
                principalSchema: "18118164",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
