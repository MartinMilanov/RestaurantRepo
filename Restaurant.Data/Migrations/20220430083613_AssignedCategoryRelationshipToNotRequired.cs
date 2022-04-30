using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Data.Migrations
{
    public partial class AssignedCategoryRelationshipToNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                schema: "18118164",
                table: "Foods");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                schema: "18118164",
                table: "Foods",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                schema: "18118164",
                table: "Foods",
                column: "CategoryId",
                principalSchema: "18118164",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                schema: "18118164",
                table: "Foods");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                schema: "18118164",
                table: "Foods",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                schema: "18118164",
                table: "Foods",
                column: "CategoryId",
                principalSchema: "18118164",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
