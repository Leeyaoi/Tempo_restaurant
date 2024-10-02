namespace Tempo_DAL.Entities;

public class Employee : BaseEntity
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public Waiter? Waiter { get; set; }
    public Cook? Cook { get; set; }
}
