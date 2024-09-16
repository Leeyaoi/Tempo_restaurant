namespace Tempo_DAL.Entities;

public class OrdersDish
{
    public Guid Id { get; set; }
    public Order Order { get; set; } = new();
    public Dish Dish { get; set; } = new();
}
