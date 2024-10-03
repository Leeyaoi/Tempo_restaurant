namespace Tempo_BLL.Models;

public class CookModel : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
    public Guid CategoryId { get; set; }

    public EmployeeModel Employee { get; set; } = new();
    public CategoryModel Category { get; set; } = new();
}
