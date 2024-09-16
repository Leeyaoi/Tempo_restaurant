namespace Tempo_DAL.Entities;

public class Order
{
    public Guid Id { get; set; }
    public int People_num { get; set; }
    public Table Table { get; set; } = new();
    public User User { get; set; } = new();
}
