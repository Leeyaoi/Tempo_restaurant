using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.CategoryDtos;

public class CreateCategoryDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
}
