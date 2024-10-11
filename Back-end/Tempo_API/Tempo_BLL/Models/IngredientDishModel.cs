namespace Tempo_BLL.Models;

public class IngredientDishModel : BaseModel
{
    public double Needed { get; set; }
    public Guid DishId { get; set; }
    public Guid IngredientId { get; set; }

    public DishModel? Dish { get; set; }
    public IngredientModel? Ingredient { get; set; } = new();
}
