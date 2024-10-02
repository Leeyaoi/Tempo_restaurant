namespace Tempo_DAL.Entities;

public class TablewareDish
{
    public Guid TablewareId { get; set; }
    public Guid DishId { get; set; }

    public Tableware Tableware { get; set; } = new();
    public Dish Dish { get; set; } = new();
}
