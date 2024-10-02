namespace Tempo_DAL.Entities;

public class EmployeeEntity : BaseEntity
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public WaiterEntity? Waiter { get; set; }
    public CookEntity? Cook { get; set; }
}
