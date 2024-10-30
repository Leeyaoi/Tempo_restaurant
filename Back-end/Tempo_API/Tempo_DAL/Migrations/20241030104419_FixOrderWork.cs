using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tempo_DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Order_OrderEntityId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Order_OrderEntityId",
                table: "Drink");

            migrationBuilder.DropIndex(
                name: "IX_Drink_OrderEntityId",
                table: "Drink");

            migrationBuilder.DropIndex(
                name: "IX_Dish_OrderEntityId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "Drink");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "Dish");

            migrationBuilder.CreateTable(
                name: "DishEntityOrderEntity",
                columns: table => new
                {
                    DishesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ordersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishEntityOrderEntity", x => new { x.DishesId, x.ordersId });
                    table.ForeignKey(
                        name: "FK_DishEntityOrderEntity_Dish_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishEntityOrderEntity_Order_ordersId",
                        column: x => x.ordersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrinkEntityOrderEntity",
                columns: table => new
                {
                    DrinksId = table.Column<Guid>(type: "uuid", nullable: false),
                    ordersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkEntityOrderEntity", x => new { x.DrinksId, x.ordersId });
                    table.ForeignKey(
                        name: "FK_DrinkEntityOrderEntity_Drink_DrinksId",
                        column: x => x.DrinksId,
                        principalTable: "Drink",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkEntityOrderEntity_Order_ordersId",
                        column: x => x.ordersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishEntityOrderEntity_ordersId",
                table: "DishEntityOrderEntity",
                column: "ordersId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkEntityOrderEntity_ordersId",
                table: "DrinkEntityOrderEntity",
                column: "ordersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishEntityOrderEntity");

            migrationBuilder.DropTable(
                name: "DrinkEntityOrderEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderEntityId",
                table: "Drink",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderEntityId",
                table: "Dish",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drink_OrderEntityId",
                table: "Drink",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_OrderEntityId",
                table: "Dish",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Order_OrderEntityId",
                table: "Dish",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Order_OrderEntityId",
                table: "Drink",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
