using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.IngredientDishDtos;

public class CreateIngredientDishDto : IBaseDto
{
    public double Needed { get; set; }
    public Guid DishId { get; set; }
    public Guid IngredientId { get; set; }
}
