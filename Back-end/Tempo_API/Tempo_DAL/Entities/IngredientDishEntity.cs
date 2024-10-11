namespace Tempo_DAL.Entities;

public class IngredientDishEntity : BaseEntity
{
    public double Needed { get; set; }
    public Guid DishId { get; set; }
    public Guid IngredientId { get; set; }

    public DishEntity? Dish { get; set; }
    public IngredientEntity? Ingredient { get; set; }
}
