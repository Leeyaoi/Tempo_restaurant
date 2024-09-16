namespace Tempo_DAL.Entities;

public class Drink
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Category Category { get; set; } = new();
}
