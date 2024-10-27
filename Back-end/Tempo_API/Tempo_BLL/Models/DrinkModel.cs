﻿namespace Tempo_BLL.Models;

public class DrinkModel : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }

    public CategoryModel? Category { get; set; }
}
