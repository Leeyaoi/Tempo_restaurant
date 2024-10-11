namespace Tempo_BLL.Models;

public class DishwareDishModel : BaseModel
{
    public Guid DishwareId { get; set; }
    public Guid DishId { get; set; }

    public DishwareModel? Dishware { get; set; }
    public DishModel? Dish { get; set; }
}
