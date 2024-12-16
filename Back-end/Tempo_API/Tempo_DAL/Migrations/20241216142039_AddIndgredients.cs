using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tempo_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIndgredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishEntityIngredientEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientEntityId",
                table: "Dish",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dish_IngredientEntityId",
                table: "Dish",
                column: "IngredientEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Ingredient_IngredientEntityId",
                table: "Dish",
                column: "IngredientEntityId",
                principalTable: "Ingredient",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Ingredient_IngredientEntityId",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_IngredientEntityId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "IngredientEntityId",
                table: "Dish");

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

            migrationBuilder.CreateIndex(
                name: "IX_DishEntityIngredientEntity_IngredientsId",
                table: "DishEntityIngredientEntity",
                column: "IngredientsId");
        }
    }
}
