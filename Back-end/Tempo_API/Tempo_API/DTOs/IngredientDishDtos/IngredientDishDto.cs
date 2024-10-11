using Tempo_API.DTOs.DishDtos;
using Tempo_API.DTOs.IngredientDtos;

namespace Tempo_API.DTOs.IngredientDishDtos;

public class IngredientDishDto
{
    public double Needed { get; set; }
    public Guid DishId { get; set; }
    public Guid IngredientId { get; set; }

    public DishDto? Dish { get; set; }
    public IngredientDto? Ingredient { get; set; }
}
