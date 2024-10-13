using Tempo_API.DTOs.IngredientDishDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.IngredientDtos;

public class IngredientDto : IBaseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double In_stock { get; set; }

    public List<IngredientDishDto?> IngredientDish { get; set; } = new();
}
