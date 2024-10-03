namespace Tempo_BLL.Models;

public class UserModel : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public List<OrderModel> Orders { get; set; } = new();
}
