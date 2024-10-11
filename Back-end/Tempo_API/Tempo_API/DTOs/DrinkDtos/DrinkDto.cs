using Tempo_API.DTOs.CategoryDtos;

namespace Tempo_API.DTOs.DrinkDtos;

public class DrinkDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }

    public CategoryDto? Category { get; set; }
}
