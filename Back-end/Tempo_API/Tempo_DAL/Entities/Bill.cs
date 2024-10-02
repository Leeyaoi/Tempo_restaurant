namespace Tempo_DAL.Entities;

public class Bill : BaseEntity
{
    public bool Cash { get; set; }
    public Guid OrderId { get; set; }

    public Order Order { get; set; } = new();
}
