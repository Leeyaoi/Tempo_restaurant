namespace Tempo_API.DTOs.IngredientDtos;

public class CreateIngredientDto
{
    public string Name { get; set; } = string.Empty;
    public double In_stock { get; set; }
}
