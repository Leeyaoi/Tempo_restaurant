namespace Tempo_DAL.Entities;

public class Tableware
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public double In_stock { get; set; }
}
