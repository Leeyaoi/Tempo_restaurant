using Tempo_Shared.Enums;

namespace Tempo_DAL.Entities;

public class OrderEntity : BaseEntity
{
    public int People_num { get; set; }
    public OrderStatus Status { get; set; }
    public Guid TableId { get; set; }
    public Guid UserId { get; set; }

    public TableEntity? Table { get; set; }
    public UserEntity? User { get; set; }
    public List<DishEntity> Dishes { get; set; } = new();
}
