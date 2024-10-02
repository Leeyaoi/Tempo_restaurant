namespace Tempo_DAL.Entities;

public class DishwareDish
{
    public Guid DishwareId { get; set; }
    public Guid DishId { get; set; }

    public Dishware Dishware { get; set; } = new();
    public Dish Dish { get; set; } = new();
}
