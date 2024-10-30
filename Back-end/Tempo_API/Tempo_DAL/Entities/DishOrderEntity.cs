namespace Tempo_DAL.Entities;

public class DishOrderEntity : BaseEntity
{
    public Guid DishId { get; set; }
    public Guid OrderId { get; set; }
    public DishEntity? Dish { get; set; }
    public OrderEntity? Order { get; set; }
}
