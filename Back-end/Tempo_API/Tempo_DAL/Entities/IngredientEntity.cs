﻿namespace Tempo_DAL.Entities;

public class IngredientEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public double In_stock {  get; set; }

    public List<IngredientDishEntity> IngredientDish { get; set; } = new();
}