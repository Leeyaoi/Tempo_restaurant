namespace Tempo_DAL.Entities;

public class Cook : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
    public Guid CategoryId { get; set; }

    public Employee Employee { get; set; } = new();
    public Category Category { get; set; } = new();
}
