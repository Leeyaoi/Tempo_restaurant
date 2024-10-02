namespace Tempo_DAL.Entities;

public class Ingredient : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public double In_stock {  get; set; }

    public List<IngredientDish> IngredientDish { get; set; } = new();
}
