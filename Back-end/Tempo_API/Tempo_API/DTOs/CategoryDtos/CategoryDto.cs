using Tempo_API.DTOs.CookDtos;
using Tempo_API.DTOs.DishDtos;
using Tempo_API.DTOs.DrinkDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.CategoryDtos;

public class CategoryDto : IBaseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<CookDto?> Cooks { get; set; } = new();
    public List<DishDto?> Dishes { get; set; } = new();
    public List<DrinkDto?> Drinks { get; set; } = new();
}
