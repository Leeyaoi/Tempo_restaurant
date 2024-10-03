namespace Tempo_BLL.Models;

public class DishwareModel : BaseModel
{
    public string Type { get; set; } = string.Empty;
    public double In_stock { get; set; }

    public List<DishwareDishModel> Dishes { get; set; } = new();
}
