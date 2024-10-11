namespace Tempo_BLL.Models;

public class DishModel : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public DateTime Approx_time { get; set; }
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }

    public CategoryModel? Category { get; set; }
    public List<DishwareDishModel?> DishwareList { get; set; } = new();
    public List<TablewareModel?> TablewareList { get; set; } = new();
}
