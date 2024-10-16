using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.OrderDtos;

public class CreateOrderDto : IBaseDto
{
    public int People_num { get; set; }
    public Guid TableId { get; set; }
    public Guid UserId { get; set; }

    public List<Guid> DishesId { get; set; } = new();
}
