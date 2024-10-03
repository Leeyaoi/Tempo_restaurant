namespace Tempo_BLL.Models;

public class WaiterModel : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }

    public EmployeeModel Employee { get; set; } = new();
    public List<TableModel> Tables { get; set; } = new();
}
