using Tempo_API.DTOs.OrderDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.BillDtos;

public class BillDto : IBaseDto
{
    public Guid Id { get; set; }
    public bool Cash { get; set; }
    public Guid OrderId { get; set; }

    public OrderDto? Order { get; set; }
}
