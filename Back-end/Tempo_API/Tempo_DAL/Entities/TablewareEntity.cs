namespace Tempo_DAL.Entities;

public class TablewareEntity : BaseEntity
{
    public string Type { get; set; } = string.Empty;
    public double In_stock { get; set; }

    public List<TablewareDishEntity> Dishes { get; set; } = new();
}
