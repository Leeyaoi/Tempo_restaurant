using Tempo_API.DTOs.DishDtos;
using Tempo_API.DTOs.DishwareDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.DishwareDishDtos;

public class DishwareDishDto : IBaseDto
{
    public Guid DishwareId { get; set; }
    public Guid DishId { get; set; }

    public DishwareDto? Dishware { get; set; }
    public DishDto? Dish { get; set; }
}
