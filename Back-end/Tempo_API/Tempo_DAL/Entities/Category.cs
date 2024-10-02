using System;
namespace Tempo_DAL.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public List<Cook> Cooks { get; set; } = new();
    public List<Dish> Dishes { get; set; } = new();
    public List<Drink> Drinks { get; set; } = new();
}
