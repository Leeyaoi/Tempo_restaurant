using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.DishDtos;

public class CreateDishDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime Approx_time { get; set; }
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}
