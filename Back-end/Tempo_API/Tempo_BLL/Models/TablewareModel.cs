namespace Tempo_BLL.Models;

public class TablewareModel : BaseModel
{
    public string Type { get; set; } = string.Empty;
    public double In_stock { get; set; }

    public List<TablewareDishModel?> Dishes { get; set; } = new();
}
