﻿using Tempo_Shared.Enums;

namespace Tempo_BLL.Models;

public class OrderModel : BaseModel
{
    public int People_num { get; set; }
    public OrderStatus Status { get; set; }
    public Guid TableId { get; set; }
    public Guid OrderId { get; set; }

    public TableModel Table { get; set; } = new();
    public UserModel User { get; set; } = new();
    public List<DishModel> Dishes { get; set; } = new();
}
