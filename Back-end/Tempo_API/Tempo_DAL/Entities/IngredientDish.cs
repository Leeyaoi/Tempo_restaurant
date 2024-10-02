namespace Tempo_DAL.Entities;

public class IngredientDish
{
    public double Needed { get; set; }
    public Guid DishId { get; set; }
    public Guid IngredientId { get; set; }

    public Dish Dish { get; set; } = new();
    public Ingredient Ingredient { get; set; } = new();
}
