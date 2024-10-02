namespace Tempo_DAL.Entities;

public class Drink : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = new();
}
