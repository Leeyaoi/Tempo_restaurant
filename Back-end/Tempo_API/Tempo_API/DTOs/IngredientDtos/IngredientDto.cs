using Tempo_API.DTOs.IngredientDishDtos;

namespace Tempo_API.DTOs.IngredientDtos;

public class IngredientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double In_stock { get; set; }

    public List<IngredientDishDto> IngredientDish { get; set; } = new();
}
