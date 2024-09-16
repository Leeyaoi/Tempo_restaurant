namespace Tempo_DAL.Entities;

public class IngredientDish
{
    public Dish Dish { get; set; } = new();
    public Ingredient Ingredient { get; set; } = new();
    public double Needed { get; set; }
}
