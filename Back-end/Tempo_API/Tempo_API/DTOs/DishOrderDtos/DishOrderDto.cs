using Tempo_API.DTOs.DishDtos;
using Tempo_API.DTOs.OrderDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.DishOrderDtos;

public class DishOrderDto : IBaseDto
{
    public Guid DishId { get; set; }
    public Guid OrderId { get; set; }
    public DishDto? Dish { get; set; }
    public OrderDto? Order { get; set; }
}
