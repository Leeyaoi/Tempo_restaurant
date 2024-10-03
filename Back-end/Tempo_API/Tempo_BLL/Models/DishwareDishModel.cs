namespace Tempo_BLL.Models;

public class DishwareDishModel
{
    public Guid DishwareId { get; set; }
    public Guid DishId { get; set; }

    public DishwareModel Dishware { get; set; } = new();
    public DishModel Dish { get; set; } = new();
}
