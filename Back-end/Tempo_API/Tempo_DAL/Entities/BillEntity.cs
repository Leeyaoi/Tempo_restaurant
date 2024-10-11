namespace Tempo_DAL.Entities;

public class BillEntity : BaseEntity
{
    public bool Cash { get; set; }
    public Guid OrderId { get; set; }

    public OrderEntity? Order { get; set; }
}
