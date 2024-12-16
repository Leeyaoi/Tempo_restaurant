namespace Tempo_DAL.Entities;

public class DrinkOrderEntity : BaseEntity
{
    public Guid DrinkId { get; set; }
    public Guid OrderId { get; set; }
    public DrinkEntity? Drink { get; set; }
    public OrderEntity? Order { get; set; }
}
