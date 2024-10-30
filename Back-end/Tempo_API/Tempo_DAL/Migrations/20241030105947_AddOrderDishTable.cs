using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tempo_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDishTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DishOrderEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DishId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishOrderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishOrderEntity_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishOrderEntity_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drink_OrderEntityId",
                table: "Drink",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DishOrderEntity_DishId",
                table: "DishOrderEntity",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishOrderEntity_OrderId",
                table: "DishOrderEntity",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Order_OrderEntityId",
                table: "Drink",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Order_OrderEntityId",
                table: "Drink");

            migrationBuilder.DropTable(
                name: "DishOrderEntity");

            migrationBuilder.DropIndex(
                name: "IX_Drink_OrderEntityId",
                table: "Drink");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "Drink");

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
    }
}
