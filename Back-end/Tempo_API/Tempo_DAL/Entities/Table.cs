namespace Tempo_DAL.Entities;

public class Table
{
    public Guid Id { get; set; }
    public int Max_people { get; set; }
    public Waiter Waiter { get; set; } = new();
}
