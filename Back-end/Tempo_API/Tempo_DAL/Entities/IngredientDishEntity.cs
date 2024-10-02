namespace Tempo_DAL.Entities;

public class IngredientDishEntity
{
    public double Needed { get; set; }
    public Guid DishId { get; set; }
    public Guid IngredientId { get; set; }

    public DishEntity Dish { get; set; } = new();
    public IngredientEntity Ingredient { get; set; } = new();
}
