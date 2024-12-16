using Tempo_API.DTOs.DishOrderDtos;
using Tempo_API.DTOs.DrinkOrderDtos;
using Tempo_API.DTOs.TableDtos;
using Tempo_API.DTOs.UserDtos;
using Tempo_API.Interfaces;
using Tempo_Shared.Enums;

namespace Tempo_API.DTOs.OrderDtos;

public class OrderDto : IBaseDto
{
    public Guid Id { get; set; }
    public int People_num { get; set; }
    public OrderStatus Status { get; set; }
    public Guid TableId { get; set; }
    public Guid UserId { get; set; }

    public TableDto? Table { get; set; }
    public UserDto? User { get; set; }
    public List<DishOrderDto> Dishes { get; set; } = new();
    public List<DrinkOrderDto> Drinks { get; set; } = new();
}
