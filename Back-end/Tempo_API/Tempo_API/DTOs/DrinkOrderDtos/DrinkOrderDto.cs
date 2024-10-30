using Tempo_API.DTOs.DrinkDtos;
using Tempo_API.DTOs.OrderDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.DrinkOrderDtos;

public class DrinkOrderDto : IBaseDto
{
    public Guid DrinkId { get; set; }
    public Guid OrderId { get; set; }
    public DrinkDto? Drink { get; set; }
    public OrderDto? Order { get; set; }
}

