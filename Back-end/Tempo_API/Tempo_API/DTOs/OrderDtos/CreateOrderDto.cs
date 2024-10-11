namespace Tempo_API.DTOs.OrderDtos;

public class CreateOrderDto
{
    public int People_num { get; set; }
    public Guid TableId { get; set; }

    public List<Guid> DishesId { get; set; } = new();
}
