namespace Tempo_BLL.Models;

public class TablewareDishModel
{
    public Guid TablewareId { get; set; }
    public Guid DishId { get; set; }

    public TablewareModel Tableware { get; set; } = new();
    public DishModel Dish { get; set; } = new();
}
