namespace Tempo_DAL.Entities;

public class Bill
{
    public Guid Id { get; set; }
    public bool Cash { get; set; }
    public Order Order { get; set; } = new();
}
