﻿namespace Tempo_DAL.Entities;

public class DishwareEntity : BaseEntity
{
    public string Type { get; set; } = string.Empty;
    public double In_stock { get; set; }

    public List<DishEntity> Dishes { get; set; } = new();
}
