namespace Tempo_DAL.Entities;

public class Ingredients_Dishes
{
    public Guid Dish_id { get; set; }
    public Guid Ingredient_id { get; set; }
    public double Needed { get; set; }
}
