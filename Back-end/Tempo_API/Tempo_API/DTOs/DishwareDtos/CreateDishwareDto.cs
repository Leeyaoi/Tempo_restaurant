using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.DishwareDtos;

public class CreateDishwareDto : IBaseDto
{
    public string Type { get; set; } = string.Empty;
    public double In_stock { get; set; }
}
