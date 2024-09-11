namespace Tempo_DAL.Entities;

public class Dishes
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public DateTime Approx_time { get; set; }
    public Decimal Price { get; set; }
    public Guid Category_id { get; set; }
}
