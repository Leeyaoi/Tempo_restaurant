namespace Tempo_DAL.Entities;

public class DrinkEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }

    public CategoryEntity? Category { get; set; }
}
