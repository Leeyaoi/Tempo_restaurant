using Tempo_Shared;

namespace Tempo_DAL.Entities;

public class Order : BaseEntity
{ 
    public int People_num { get; set; }
    public OrderStatus Status { get; set; }
    public Guid TableId { get; set; }
    public Guid OrderId { get; set; }

    public Table Table { get; set; } = new();
    public User User { get; set; } = new();
    public List<Dish> Dishes { get; set; } = new();
}
