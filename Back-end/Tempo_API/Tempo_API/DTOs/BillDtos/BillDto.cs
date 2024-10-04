using Tempo_API.DTOs.OrderDtos;

namespace Tempo_API.DTOs.BillDtos;

public class BillDto
{
    public Guid Id { get; set; }
    public bool Cash { get; set; }
    public Guid OrderId { get; set; }

    public OrderDto Order { get; set; } = new();
}
