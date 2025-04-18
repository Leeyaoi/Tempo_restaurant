﻿namespace Tempo_DAL.Entities;

public class TableEntity : BaseEntity
{
    public int Max_people { get; set; }
    public Guid WaiterId { get; set; }
    public int Number { get; set; }

    public List<OrderEntity> OrderList { get; set; } = new();
    public WaiterEntity? Waiter { get; set; }
}
