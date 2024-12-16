using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.DishDtos;

public class CreateDishDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
    public int Approx_time { get; set; }
    public string Photo { get; set; } = string.Empty;
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}
