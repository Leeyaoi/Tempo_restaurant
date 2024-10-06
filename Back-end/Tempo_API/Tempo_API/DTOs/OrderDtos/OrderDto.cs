using Tempo_API.DTOs.DishDtos;
using Tempo_API.DTOs.TableDtos;
using Tempo_API.DTOs.UserDtos;
using Tempo_Shared.Enums;

namespace Tempo_API.DTOs.OrderDtos;

public class OrderDto
{
    public Guid Id { get; set; }
    public int People_num { get; set; }
    public OrderStatus Status { get; set; }
    public Guid TableId { get; set; }
    public Guid OrderId { get; set; }
    public List<Guid> DishesId { get; set; } = new();

    public TableDto Table { get; set; } = new();
    public UserDto User { get; set; } = new();
    public List<DishDto> Dishes { get; set; } = new();
}
