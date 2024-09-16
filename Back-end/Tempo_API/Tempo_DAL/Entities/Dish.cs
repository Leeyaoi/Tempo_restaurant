namespace Tempo_DAL.Entities;

public class Dish
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Approx_time { get; set; }
    public Decimal Price { get; set; }
    public Category Category { get; set; } = new();
}
