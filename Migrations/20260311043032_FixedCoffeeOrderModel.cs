using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeQueueApp.Migrations
{
    /// <inheritdoc />
    public partial class FixedCoffeeOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeOrder_Baristas_BaristaId",
                table: "CoffeeOrder");

            migrationBuilder.AlterColumn<int>(
                name: "BaristaId",
                table: "CoffeeOrder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeOrder_Baristas_BaristaId",
                table: "CoffeeOrder",
                column: "BaristaId",
                principalTable: "Baristas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeOrder_Baristas_BaristaId",
                table: "CoffeeOrder");

            migrationBuilder.AlterColumn<int>(
                name: "BaristaId",
                table: "CoffeeOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeOrder_Baristas_BaristaId",
                table: "CoffeeOrder",
                column: "BaristaId",
                principalTable: "Baristas",
                principalColumn: "Id");
        }
    }
}
