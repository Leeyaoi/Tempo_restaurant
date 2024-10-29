namespace Tempo_DAL.Entities;

public class DishEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Approx_time { get; set; }
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public string Photo { get; set; } = string.Empty;

    public CategoryEntity? Category { get; set; }
    public List<DishwareEntity> DishwareList { get; set; } = new();
    public List<TablewareEntity> TablewareList { get; set; } = new();
    public List<IngredientEntity> Ingredients { get; set; } = new();
}
