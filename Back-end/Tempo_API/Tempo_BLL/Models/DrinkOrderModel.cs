namespace Tempo_BLL.Models;

public class DrinkOrderModel : BaseModel
{
    public Guid DrinkId { get; set; }
    public Guid OrderId { get; set; }
    public DrinkModel? Drink { get; set; }
    public OrderModel? Order { get; set; }
}