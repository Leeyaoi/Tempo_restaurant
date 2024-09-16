namespace Tempo_DAL.Entities;

public class TablewareDish
{
    public Tableware Tableware { get; set; } = new();
    public Dish Dish { get; set; } = new();
}
