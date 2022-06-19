using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Data.Migrations
{
    public partial class IsReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Tables_TableId",
                schema: "18118164",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodBills_Bills_BillId",
                schema: "18118164",
                table: "FoodBills");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodBills_Foods_FoodId",
                schema: "18118164",
                table: "FoodBills");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableId",
                schema: "18118164",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "TableId",
                schema: "18118164",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TableId",
                schema: "18118164",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Tables_TableId",
                schema: "18118164",
                table: "Bills",
                column: "TableId",
                principalSchema: "18118164",
                principalTable: "Tables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodBills_Bills_BillId",
                schema: "18118164",
                table: "FoodBills",
                column: "BillId",
                principalSchema: "18118164",
                principalTable: "Bills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodBills_Foods_FoodId",
                schema: "18118164",
                table: "FoodBills",
                column: "FoodId",
                principalSchema: "18118164",
                principalTable: "Foods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableId",
                schema: "18118164",
                table: "Reservations",
                column: "TableId",
                principalSchema: "18118164",
                principalTable: "Tables",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Tables_TableId",
                schema: "18118164",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodBills_Bills_BillId",
                schema: "18118164",
                table: "FoodBills");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodBills_Foods_FoodId",
                schema: "18118164",
                table: "FoodBills");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableId",
                schema: "18118164",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "TableId",
                schema: "18118164",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TableId",
                schema: "18118164",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
                name: "FK_FoodBills_Bills_BillId",
                schema: "18118164",
                table: "FoodBills",
                column: "BillId",
                principalSchema: "18118164",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodBills_Foods_FoodId",
                schema: "18118164",
                table: "FoodBills",
                column: "FoodId",
                principalSchema: "18118164",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
