using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tempo_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDrinkTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrderEntity_Dish_DishId",
                table: "DishOrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrderEntity_Order_OrderId",
                table: "DishOrderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrderEntity",
                table: "DishOrderEntity");

            migrationBuilder.RenameTable(
                name: "DishOrderEntity",
                newName: "DishOrder");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrderEntity_OrderId",
                table: "DishOrder",
                newName: "IX_DishOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrderEntity_DishId",
                table: "DishOrder",
                newName: "IX_DishOrder_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DrinkOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DrinkId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrinkOrder_Drink_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drink",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrinkOrder_DrinkId",
                table: "DrinkOrder",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkOrder_OrderId",
                table: "DrinkOrder",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Dish_DishId",
                table: "DishOrder",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Order_OrderId",
                table: "DishOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Dish_DishId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Order_OrderId",
                table: "DishOrder");

            migrationBuilder.DropTable(
                name: "DrinkOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder");

            migrationBuilder.RenameTable(
                name: "DishOrder",
                newName: "DishOrderEntity");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrder_OrderId",
                table: "DishOrderEntity",
                newName: "IX_DishOrderEntity_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrder_DishId",
                table: "DishOrderEntity",
                newName: "IX_DishOrderEntity_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrderEntity",
                table: "DishOrderEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrderEntity_Dish_DishId",
                table: "DishOrderEntity",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrderEntity_Order_OrderId",
                table: "DishOrderEntity",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
