using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tempo_DAL.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DishEntityDishwareEntity",
                columns: table => new
                {
                    DishesId = table.Column<Guid>(type: "uuid", nullable: false),
                    DishwareListId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishEntityDishwareEntity", x => new { x.DishesId, x.DishwareListId });
                    table.ForeignKey(
                        name: "FK_DishEntityDishwareEntity_Dish_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishEntityDishwareEntity_Dishware_DishwareListId",
                        column: x => x.DishwareListId,
                        principalTable: "Dishware",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishEntityIngredientEntity",
                columns: table => new
                {
                    DishesId = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishEntityIngredientEntity", x => new { x.DishesId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_DishEntityIngredientEntity_Dish_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishEntityIngredientEntity_Ingredient_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishEntityTablewareEntity",
                columns: table => new
                {
                    DishesId = table.Column<Guid>(type: "uuid", nullable: false),
                    TablewareListId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishEntityTablewareEntity", x => new { x.DishesId, x.TablewareListId });
                    table.ForeignKey(
                        name: "FK_DishEntityTablewareEntity_Dish_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishEntityTablewareEntity_Tableware_TablewareListId",
                        column: x => x.TablewareListId,
                        principalTable: "Tableware",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishEntityDishwareEntity_DishwareListId",
                table: "DishEntityDishwareEntity",
                column: "DishwareListId");

            migrationBuilder.CreateIndex(
                name: "IX_DishEntityIngredientEntity_IngredientsId",
                table: "DishEntityIngredientEntity",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_DishEntityTablewareEntity_TablewareListId",
                table: "DishEntityTablewareEntity",
                column: "TablewareListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishEntityDishwareEntity");

            migrationBuilder.DropTable(
                name: "DishEntityIngredientEntity");

            migrationBuilder.DropTable(
                name: "DishEntityTablewareEntity");
        }
    }
}
