namespace Tempo_DAL.Entities;

public class Waiter : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }

    public Employee Employee { get; set; } = new();
    public List<Table> Tables { get; set; } = new();
}
