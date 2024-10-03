namespace Tempo_BLL.Models;

public class IngredientDishModel
{
    public double Needed { get; set; }
    public Guid DishId { get; set; }
    public Guid IngredientId { get; set; }

    public DishModel Dish { get; set; } = new();
    public IngredientModel Ingredient { get; set; } = new();
}
