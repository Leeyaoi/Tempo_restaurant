using Tempo_Shared.Enums;

namespace Tempo_BLL.Models;

public class OrderModel : BaseModel
{
    public int People_num { get; set; }
    public OrderStatus Status { get; set; }
    public Guid TableId { get; set; }
    public Guid UserId { get; set; }
    public List<Guid> DishesId { get; set; } = new();
    public List<Guid> DrinksId { get; set; } = new();

    public TableModel? Table { get; set; }
    public UserModel? User { get; set; }
    public List<DishOrderModel> Dishes { get; set; } = new();
    public List<DrinkOrderModel> Drinks { get; set; } = new();
}
