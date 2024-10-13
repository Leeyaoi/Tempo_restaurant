using Tempo_API.DTOs.DishwareDishDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.DishwareDtos;

public class DishwareDto : IBaseDto
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public double In_stock { get; set; }

    public List<DishwareDishDto?> Dishes { get; set; } = new();
}
