namespace Tempo_BLL.Models;

public class IngredientModel : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public double In_stock { get; set; }

    public List<IngredientDishModel> IngredientDish { get; set; } = new();
}