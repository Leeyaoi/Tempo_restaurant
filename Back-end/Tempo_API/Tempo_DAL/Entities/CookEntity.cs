namespace Tempo_DAL.Entities;

public class CookEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
    public Guid CategoryId { get; set; }

    public EmployeeEntity? Employee { get; set; }
    public CategoryEntity? Category { get; set; }
}
