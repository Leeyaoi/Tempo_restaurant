using Tempo_API.DTOs.OrderDtos;
using Tempo_API.DTOs.WaiterDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.TableDtos;

public class TableDto : IBaseDto
{
    public Guid Id { get; set; }
    public int Max_people { get; set; }
    public Guid WaiterId { get; set; }
    public int Number { get; set; }

    public List<OrderDto?> OrderList { get; set; } = new();
    public WaiterDto? Waiter { get; set; }
}
