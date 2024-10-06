using Tempo_Shared.Enums;

namespace Tempo_DAL.Entities;

public class OrderEntity : BaseEntity
{ 
    public int People_num { get; set; }
    public OrderStatus Status { get; set; }
    public Guid TableId { get; set; }
    public Guid OrderId { get; set; }

    public TableEntity Table { get; set; } = new();
    public UserEntity User { get; set; } = new();
    public List<DishEntity> Dishes { get; set; } = new();
}
