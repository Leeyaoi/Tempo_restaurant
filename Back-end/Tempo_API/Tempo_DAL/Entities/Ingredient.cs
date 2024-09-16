namespace Tempo_DAL.Entities;

public class Ingredient
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double In_stock {  get; set; }
}
