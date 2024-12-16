namespace Tempo_DAL.Entities;

public class DrinkEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public Decimal Price { get; set; }
    public string Photo { get; set; } = string.Empty;

    public CategoryEntity? Category { get; set; }
}
