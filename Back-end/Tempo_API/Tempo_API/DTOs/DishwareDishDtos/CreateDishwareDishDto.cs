using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.DishwareDishDtos;

public class CreateDishwareDishDto : IBaseDto
{
    public Guid DishwareId { get; set; }
    public Guid DishId { get; set; }
}
