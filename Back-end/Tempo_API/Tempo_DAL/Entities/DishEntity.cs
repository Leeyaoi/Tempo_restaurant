namespace Tempo_DAL.Entities;

public class DishEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public DateTime Approx_time { get; set; }
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }

    public CategoryEntity? Category { get; set; }
    public List<DishwareDishEntity?> DishwareList { get; set;} = new();
    public List<TablewareEntity?> TablewareList { get; set; } = new();
}
