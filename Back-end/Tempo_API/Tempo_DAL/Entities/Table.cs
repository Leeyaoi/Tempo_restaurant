namespace Tempo_DAL.Entities;

public class Table : BaseEntity
{
    public int Max_people { get; set; }
    public Guid WaiterId { get; set; }

    public List<Order> OrderList { get; set; } = new();
    public Waiter Waiter { get; set; } = new();
}
