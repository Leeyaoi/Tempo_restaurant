using System;
namespace Tempo_DAL.Entities;

public class CategoryEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public List<CookEntity> Cooks { get; set; } = new();
    public List<DishEntity> Dishes { get; set; } = new();
    public List<DrinkEntity> Drinks { get; set; } = new();
}
