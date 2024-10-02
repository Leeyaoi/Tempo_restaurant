namespace Tempo_DAL.Entities;

public class TablewareDishEntity
{
    public Guid TablewareId { get; set; }
    public Guid DishId { get; set; }

    public TablewareEntity Tableware { get; set; } = new();
    public DishEntity Dish { get; set; } = new();
}
