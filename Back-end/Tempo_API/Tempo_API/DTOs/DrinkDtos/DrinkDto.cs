using Tempo_API.DTOs.CategoryDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.DrinkDtos;

public class DrinkDto : IBaseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public string Photo { get; set; } = string.Empty;

    public CategoryDto? Category { get; set; }
}
