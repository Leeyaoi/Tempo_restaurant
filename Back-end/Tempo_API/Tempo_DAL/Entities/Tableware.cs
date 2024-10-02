namespace Tempo_DAL.Entities;

public class Tableware : BaseEntity
{
    public string Type { get; set; } = string.Empty;
    public double In_stock { get; set; }

    public List<TablewareDish> Dishes { get; set; } = new();
}
