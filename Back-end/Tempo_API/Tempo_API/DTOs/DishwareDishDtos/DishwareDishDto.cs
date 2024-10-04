using Tempo_API.DTOs.DishDtos;
using Tempo_API.DTOs.DishwareDtos;

namespace Tempo_API.DTOs.DishwareDishDtos;

public class DishwareDishDto
{
    public Guid DishwareId { get; set; }
    public Guid DishId { get; set; }

    public DishwareDto Dishware { get; set; } = new();
    public DishDto Dish { get; set; } = new();
}
