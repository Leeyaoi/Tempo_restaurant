namespace Tempo_DAL.Entities;

public class Dish : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public DateTime Approx_time { get; set; }
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = new();
    public List<DishwareDish> DishwareList { get; set;} = new();
    public List<Tableware> TablewareList { get; set; } = new();
}
