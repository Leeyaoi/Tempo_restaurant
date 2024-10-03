namespace Tempo_BLL.Models;

public class CategoryModel : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public List<CookModel> Cooks { get; set; } = new();
    public List<DishModel> Dishes { get; set; } = new();
    public List<DrinkModel> Drinks { get; set; } = new();
}
