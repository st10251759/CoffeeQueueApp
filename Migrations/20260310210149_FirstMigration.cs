using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeQueueApp.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baristas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Shift = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baristas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeOrder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Drink = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Milk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sugar = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaristaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeOrder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CoffeeOrder_Baristas_BaristaId",
                        column: x => x.BaristaId,
                        principalTable: "Baristas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeOrder_BaristaId",
                table: "CoffeeOrder",
                column: "BaristaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeOrder");

            migrationBuilder.DropTable(
                name: "Baristas");
        }
    }
}
