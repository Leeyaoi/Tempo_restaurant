namespace Tempo_DAL.Entities;

public class DishwareDishEntity : BaseEntity
{
    public Guid DishwareId { get; set; }
    public Guid DishId { get; set; }

    public DishwareEntity? Dishware { get; set; }
    public DishEntity? Dish { get; set; }
}
