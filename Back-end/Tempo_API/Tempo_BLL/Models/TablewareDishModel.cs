﻿namespace Tempo_BLL.Models;

public class TablewareDishModel : BaseModel
{
    public Guid TablewareId { get; set; }
    public Guid DishId { get; set; }

    public TablewareModel? Tableware { get; set; }
    public DishModel? Dish { get; set; }
}
