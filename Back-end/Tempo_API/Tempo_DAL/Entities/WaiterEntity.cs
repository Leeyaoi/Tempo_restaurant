namespace Tempo_DAL.Entities;

public class WaiterEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }

    public EmployeeEntity Employee { get; set; } = new();
    public List<TableEntity> Tables { get; set; } = new();
}
