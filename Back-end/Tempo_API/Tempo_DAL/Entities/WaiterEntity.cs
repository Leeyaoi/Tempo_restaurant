namespace Tempo_DAL.Entities;

public class WaiterEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }

    public EmployeeEntity? Employee { get; set; }
    public List<TableEntity> Tables { get; set; } = new();
}
