namespace Tempo_BLL.Models;

public class BillModel : BaseModel
{
    public bool Cash { get; set; }
    public Guid OrderId { get; set; }

    public OrderModel Order { get; set; } = new();
}
