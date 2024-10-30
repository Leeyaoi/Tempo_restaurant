namespace Tempo_BLL.Models;

public class DishOrderModel : BaseModel
{
    public Guid DishId { get; set; }
    public Guid OrderId { get; set; }
    public DishModel? Dish { get; set; }
    public OrderModel? Order { get; set; }
}
