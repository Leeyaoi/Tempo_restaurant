namespace Tempo_API.DTOs.DishDtos;

public class CreateDishDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime Approx_time { get; set; }
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}
