namespace Tempo_BLL.Models;

public class EmployeeModel : BaseModel
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public WaiterModel? Waiter { get; set; }
    public CookModel? Cook { get; set; }
}
