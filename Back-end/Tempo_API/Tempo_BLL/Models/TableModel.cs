namespace Tempo_BLL.Models;

public class TableModel : BaseModel
{
    public int Max_people { get; set; }
    public Guid WaiterId { get; set; }

    public List<OrderModel?> OrderList { get; set; } = new();
    public WaiterModel? Waiter { get; set; }
}
