using Tempo_API.DTOs.DishDtos;
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
    public List<Guid> DishesId { get; set; } = new();
    public Guid UserId { get; set; }

    public TableDto? Table { get; set; }
    public UserDto? User { get; set; }
    public List<DishDto?> Dishes { get; set; } = new();
}
