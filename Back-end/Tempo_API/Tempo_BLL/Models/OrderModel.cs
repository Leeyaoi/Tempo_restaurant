using Tempo_Shared.Enums;

namespace Tempo_BLL.Models;

public class OrderModel : BaseModel
{
    public int People_num { get; set; }
    public OrderStatus Status { get; set; }
    public Guid TableId { get; set; }
    public Guid UserId { get; set; }

    public TableModel? Table { get; set; }
    public UserModel? User { get; set; }
    public List<DishModel> Dishes { get; set; } = new();
    public List<DrinkModel> Drinks { get; set; } = new();
}
